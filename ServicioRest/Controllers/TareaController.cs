using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica;
using Entidades;

namespace ServicioRest.Controllers
{
    public class TareaServicio
    {
        public int IDTarea { get; set; }

        [Required(ErrorMessage = "El campo IDPedido es obligatorio")]
        public int IDPedido { get; set; }

        [Required(ErrorMessage = "El campo CostoMateriales es obligatorio")]
        public int CostoMateriales { get; set; }

        [Required(ErrorMessage = "El campo CostoManoDeObra es obligatorio")]
        public int CostoManoDeObra { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int CostoTotal { get; }

        public string EstadoTarea { get; set; }
    }

    public class TareaController : ApiController
    {      
        public TareaServicio ConvertirATareaServicio(TareaLogica tareaLogica)
        {
            if (tareaLogica != null)
            {
                return new TareaServicio
                {
                    IDPedido = tareaLogica.IDPedido,
                    IDTarea = tareaLogica.IDTarea,
                    CostoMateriales = tareaLogica.CostoMateriales,
                    CostoManoDeObra = tareaLogica.CostoManoDeObra,
                    FechaCreacion = tareaLogica.FechaCreacion,
                    EstadoTarea = tareaLogica.EstadoTarea
                };
            }

            return null;
        }

        public IHttpActionResult Post([FromBody] TareaServicio tareaServicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TareaServicio tarea = ConvertirATareaServicio(Principal.Instance.DarAltaTarea(tareaServicio.IDPedido, tareaServicio.CostoMateriales, tareaServicio.CostoManoDeObra));

            if (tarea != null)
            {
                return Created<TareaServicio>("", tarea);
            }

            return BadRequest();
        }

        public IHttpActionResult Get(string estado = "")
        {
            List<TareaServicio> tareas = Principal.Instance.RetornarListadoTareas().Select(x => new TareaServicio { IDPedido = x.IDPedido, CostoMateriales = x.CostoMateriales, CostoManoDeObra = x.CostoManoDeObra, EstadoTarea = x.EstadoTarea, FechaCreacion = x.FechaCreacion, IDTarea = x.IDTarea }).ToList();

            if (estado != "")
            {
                tareas = tareas.Where(x => x.EstadoTarea == estado).ToList();
            }

            if (tareas != null)
            {
                return Ok(tareas);
            }

            return BadRequest();
        }

        public IHttpActionResult Get(int id)
        {
            TareaServicio tarea = ConvertirATareaServicio(Principal.Instance.RetornarTarea(id));

            if (tarea != null)
            {
                return Ok(tarea);
            }

            return BadRequest();
        }

        public IHttpActionResult Put(int id)
        {
            TareaServicio tarea = ConvertirATareaServicio(Principal.Instance.ActualizarTarea(id));

            if (tarea != null)
            {
                return Ok(tarea);
            }

            return BadRequest();
        }
    }
}

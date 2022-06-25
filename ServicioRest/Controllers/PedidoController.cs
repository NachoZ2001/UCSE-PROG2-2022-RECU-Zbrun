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
    public class PedidoServicio 
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo NombreSolicitante es obligatorio")]
        public string NombreSolicitante { get; set; }

        [Required(ErrorMessage = "El campo NombreArea es obligatorio")]
        public string NombreArea { get; set; }

        [Required(ErrorMessage = "El campo DescripcionPedido es obligatorio")]
        public string DescripcionPedido { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
    public class PedidoController : ApiController
    {
        public PedidoServicio ConvertirAPedidoServicio(PedidoLogica pedidoLogica)
        {
            return new PedidoServicio
            {
                ID = pedidoLogica.ID,
                NombreSolicitante = pedidoLogica.NombreSolicitante,
                NombreArea = pedidoLogica.NombreArea,
                DescripcionPedido = pedidoLogica.DescripcionPedido,
                FechaCreacion = pedidoLogica.FechaCreacion
            };
        }

        public IHttpActionResult Post([FromBody] PedidoServicio pedidoServicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PedidoServicio pedido = ConvertirAPedidoServicio(Principal.Instance.DarAltaPedido(pedidoServicio.NombreSolicitante, pedidoServicio.NombreArea, pedidoServicio.DescripcionPedido));

            return Created<PedidoServicio>("", pedido);
        }
    }
}

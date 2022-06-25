using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class Principal
    {
        private static Principal instance;

        private Principal() { }

        public static Principal Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Principal();
                }
                return instance;
            }
        }

        Random Random = new Random();

        private List<PedidoLogica> pedidos = new List<PedidoLogica>
        {
            new PedidoLogica{ID = 2, NombreArea = "Ramona", NombreSolicitante = "Pablo", DescripcionPedido = "Hospital", FechaCreacion = DateTime.Now.Date}
        };

        private List<TareaLogica> tareas = new List<TareaLogica>
        {
            new TareaLogica{IDPedido = 2, CostoMateriales = 1000, CostoManoDeObra = 2000, IDTarea = 3, EstadoTarea = "PENDIENTE", FechaCreacion = DateTime.Now.Date}
        };

        public PedidoLogica DarAltaPedido(string nombreSolicitante, string nombreArea, string descripcionPedido)
        {
            PedidoLogica nuevoPedido = new PedidoLogica { ID = Random.Next(), NombreSolicitante = nombreSolicitante, NombreArea = nombreArea, DescripcionPedido = descripcionPedido, FechaCreacion = DateTime.Now.Date };

            pedidos.Add(nuevoPedido);

            return nuevoPedido;
        }

        public TareaLogica DarAltaTarea(int IDPedido, int costoMateriales, int costoManoDeObra)
        {
            if (IDPedido != 0 && costoManoDeObra != 0 && costoMateriales != 0)
            {
                if (pedidos.Exists(x => x.ID == IDPedido))
                {
                    TareaLogica nuevaTarea = new TareaLogica { IDPedido = IDPedido, IDTarea = Random.Next(), CostoMateriales = costoMateriales, CostoManoDeObra = costoManoDeObra, FechaCreacion = DateTime.Now.Date, EstadoTarea = "PENDIENTE" };

                    tareas.Add(nuevaTarea);

                    return nuevaTarea;
                }
            }

            return null;
        }

        public List<TareaLogica> RetornarListadoTareas()
        {
            return tareas;
        }

        public TareaLogica RetornarTarea(int IDTarea)
        {
            return tareas.FirstOrDefault(x => x.IDTarea == IDTarea);
        }

        public TareaLogica ActualizarTarea(int IDTarea)
        {
            TareaLogica tarea = tareas.FirstOrDefault(x => x.IDTarea == IDTarea);

            if (tarea != null)
            {
                tarea.EstadoTarea = "COMPLETADA";
            }

            return tarea;
        }
    }
}

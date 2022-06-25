using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PedidoLogica
    {
        public int ID { get; set; }
        public string NombreSolicitante { get; set; }
        public string NombreArea { get; set; }
        public string DescripcionPedido { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
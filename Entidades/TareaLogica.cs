using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TareaLogica
    {
        public int IDTarea { get; set; }
        public int IDPedido { get; set; }
        public int CostoMateriales { get; set; }
        public int CostoManoDeObra { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CostoTotal { get; }
        public string EstadoTarea { get; set; }
    }
}

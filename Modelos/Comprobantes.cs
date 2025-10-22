using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Comprobantes
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string numero { get; set; }
        public decimal monto { get; set; }
        public DateTime fecha { get; set; }
        public TipoComprobantes tipoComprobante {get;set;}
    }
}

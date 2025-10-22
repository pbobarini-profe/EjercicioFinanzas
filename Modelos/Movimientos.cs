using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Movimientos
    {
        public int id { get; set; }
        public Cuentas cuenta { get; set; }
        public Comprobantes comprobante { get; set; }
        public int debeHaber { get; set; } //1-Debe | 2-Haber
        public decimal monto { get; set; }
    }
}

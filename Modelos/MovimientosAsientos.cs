using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class MovimientosAsientos
    {
         public int id { get; set; }
        public Movimientos movimiento { get; set; }
        public Asientos asiento { get; set; }
    }
}

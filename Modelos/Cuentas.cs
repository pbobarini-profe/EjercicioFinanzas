using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Cuentas
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public Rubros rubro{ get; set; }
    }
}

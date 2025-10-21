using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Rubros
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int tipoRubro { get; set; } //1-activo / 2-pasivo / 3-Patrimonio Neto / 4-Ingresos / 5-Egregsos
    }
}

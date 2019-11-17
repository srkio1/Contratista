using System;
using System.Collections.Generic;
using System.Text;

namespace Contratista.Datos
{
    public class Promocion_material
    {
        public int id_promocion_m { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public int id_material { get; set; }
    }
}

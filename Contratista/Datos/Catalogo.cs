using System;
using System.Collections.Generic;
using System.Text;

namespace Contratista.Datos
{
    public class Catalogo
    {
        public int id_catalogo { get; set; }
        public string nombre { get; set; }
        public string imagen_1 { get; set; }
        public string imagen_2 { get; set; }
        public string descripcion { get; set; }
        public int id_servicio { get; set; }
    }
}

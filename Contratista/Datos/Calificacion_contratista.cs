using System;
using System.Collections.Generic;
using System.Text;

namespace Contratista.Datos
{
   public class Calificacion_contratista
    {
        public int id_calificacion_c { get; set; }
        public string valor { get; set; }
        public string comentarios { get; set; }
        public int id_contratista { get; set; }
        public int telefono { get; set; }
    }
}

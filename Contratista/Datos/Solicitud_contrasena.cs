using System;
using System.Collections.Generic;
using System.Text;

namespace Contratista.Datos
{
    public class Solicitud_contrasena
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string comentario { get; set; }
        public DateTime fecha { get; set; }
    }
}

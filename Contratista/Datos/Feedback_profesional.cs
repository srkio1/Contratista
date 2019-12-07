using System;
using System.Collections.Generic;
using System.Text;

namespace Contratista.Datos
{
    public class Feedback_profesional
    {
        public int id_feedback_p { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int id_profesional { get; set; }
    }
}

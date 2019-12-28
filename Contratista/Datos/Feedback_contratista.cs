using System;
using System.Collections.Generic;
using System.Text;

namespace Contratista.Datos
{
    public class Feedback_contratista
    {
        public int id_feedback_c { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int id_contratistas { get; set; }
    }
}

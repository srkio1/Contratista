using System;
using System.Collections.Generic;
using System.Text;

namespace Contratista.Datos
{
    public class Calificacion_empresa
    {
        public int id_calificacion_e { get; set; }
        public string valor { get; set; }
        public string comentarios { get; set; }
        public int telefono { get; set; }
        public int id_empresa { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Contratista.Datos
{
    public class Profesional
    {
        public int id_profesional { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public int telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string foto { get; set; }
        public string cedula_identidad { get; set; }
        public string rubro { get; set; }
        public decimal calificacion { get; set; }
        public string estado { get; set; }
        public int prioridad { get; set; }
        public string descripcion { get; set; }
        public int nit { get; set; }
        public string curriculum { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string DisplayTextNombre { get { return $"{nombre} {apellido_paterno} {apellido_materno}"; } }
    }
}

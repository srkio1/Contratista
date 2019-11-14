using System;
using System.Collections.Generic;
using System.Text;

namespace Contratista.Datos
{
    public class Empresa
    {
        public int id_empresa { get; set; }
        public string nombre { get; set; }
        public int telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string ubicacion_lat { get; set; }
        public string ubicacion_long { get; set; }
        public string foto { get; set; }
        public int nit { get; set; }
        public string rubro { get; set; }
        public decimal calificacion { get; set; }
        public int prioridad { get; set; }
        public string descripcion { get; set; }
        public string fundaempresa { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
    }
}

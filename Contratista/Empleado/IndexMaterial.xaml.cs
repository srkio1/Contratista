using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista.Empleado
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IndexMaterial : TabbedPage
	{
        public IndexMaterial(int id_material, string nombre, int telefono, string email, string rubro, int prioridad, decimal calificacion, string foto, string descripcion,
                            int nit)
        {
            InitializeComponent();
            int idMaterial = id_material;
            txtNombre.Text = nombre;
            txtTelefono.Text = telefono.ToString();
            txtEmail.Text = email;
            txtRubro.Text = rubro;
            txtPrioridad.Text = prioridad.ToString();
            txtDescripcion.Text = descripcion;
            txtNit.Text = nit.ToString();
            img_perfil.Source = "http://dmrbolivia.online" + foto;
        }
    }
}
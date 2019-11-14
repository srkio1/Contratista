using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contratista.Feed_Back;

namespace Contratista.Empleado
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IndexEmpleado : TabbedPage
	{
        public IndexEmpleado(int id_contratista, string nombre, string apellido_paterno, string apeliido_maternos, int telefono, string rubro, string estado,
                             decimal calificacion, string foto, string descripcion)
        {
            InitializeComponent();
            idEntry.Text = id_contratista.ToString();
            txtNombre.Text = nombre + " " + apellido_paterno + " " + apeliido_maternos;
            txtTelefono.Text = telefono.ToString();
            txtRubro.Text = rubro;
            txtEstado.Text = estado;
            txtCalificacion.Text = calificacion.ToString();
            txtDescripcion.Text = descripcion;
            img_perfil.Source = "http://dmrbolivia.online" + foto;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Nuevo trabajo", "NO", "SI", "Aceptar trabajo?");
            switch (action)
            {
                case "SI":
                    await Navigation.PushAsync(new TrabajoEmpleado());
                    break;
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactanosContratista());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TrabajoEmpleado());
        }
    }
}
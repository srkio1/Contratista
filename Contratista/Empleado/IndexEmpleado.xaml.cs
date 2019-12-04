using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratista.Datos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contratista.Feed_Back;

namespace Contratista.Empleado
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IndexEmpleado : TabbedPage
	{
        private int IdContratista;
        private string Nombre;
        private string Apellidop;
        private string Apellidom;
        private int Telefono;
        private string Direccion;
        private string Foto;
        private string Cedulaidentidad;
        private string Rubro;
        private decimal Calififacion;
        private string Estadoo;
        private int Prioridad;
        private string Descripcion;
        private int Nit;
        private string Usuario;
        private string Contrasena;

        public IndexEmpleado(int id_contratista, string nombre, string apellido_paterno, string apeliido_materno, int telefono, string direccion, string foto , string cedulaidentidad, string rubro,
                             decimal calificacion, string estado, int prioridad,  string descripcion , int nit, string usuario, string contrasena)
        {
            InitializeComponent();

            IdContratista = id_contratista;
            Nombre = nombre;
            Apellidop = apellido_paterno;
            Apellidom = apeliido_materno;
            Telefono = telefono;
            Direccion = direccion;
            Foto = foto;
            Cedulaidentidad = cedulaidentidad;
            Rubro = rubro;
            Calififacion = calificacion;
            Estadoo = estado;
            Prioridad = prioridad;
            Descripcion = descripcion;
            Nit = nit;
            Usuario = usuario;
            Contrasena = contrasena;




            idEntry.Text = id_contratista.ToString();
            txtNombre.Text = nombre + " " + apellido_paterno + " " + apeliido_materno;
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

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModificarEmpleado(IdContratista, Nombre , Apellidop , Apellidom , Telefono , Direccion , Foto ,Cedulaidentidad , Rubro , Calififacion , Estadoo , Prioridad , Descripcion , Nit , Usuario , Contrasena));
        }
    }
}
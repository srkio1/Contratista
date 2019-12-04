using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Contratista.Datos;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista.Empleado
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModificarEmpleado : ContentPage
	{
        private int IdContratista1;
        private string Nombre1;
        private string Apellidop1;
        private string Apellidom1;
        private int Telefono1;
        private string Direccion1;
        private string Foto1;
        private string Cedulaidentidad1;
        private string Rubro1;      
        private decimal Calififacion1;
        private string Estadoo1;
        private int Prioridad1;
        private string Descripcion1;        
        private int Nit1;
        private string Usuario1;
        private string Contrasena1;

        public ModificarEmpleado (int Idcontratista, string Nombre , string Apellidop , string Apellidom , int Telefono ,
            string Direccion , string Foto,
            string Cedulaidentidad, string Rubro, decimal Calififacion, string Estado , int Prioridad, string Descripcion, int Nit ,
            string Usuario, string Contrasena)
		{
            InitializeComponent();

            IdContratista1 = Idcontratista;
            Nombre1 = Nombre;
            Apellidop1 = Apellidop;
            Apellidom1 = Apellidom;
            Telefono1 = Telefono;
            Direccion1 = Direccion;
            Foto1 = Foto;
            Cedulaidentidad1 = Cedulaidentidad;
            Rubro1 = Rubro;
            Calififacion1 = Calififacion;
            Estadoo1 = Estado;
            Prioridad1 = Prioridad;
            Descripcion1 = Descripcion;
            Nit1 = Nit;
            Usuario1 = Usuario;
            Contrasena1 = Contrasena;

            nombreentry.Text = Nombre;
            apellidopEntry.Text = Apellidop;
            apellidomEntry.Text = Apellidom;
            telefonoentry.Text = Telefono.ToString();
            direntry.Text = Direccion;
            carnetentry.Text = Cedulaidentidad;
            rubroentry.Text = Rubro;
            estadoentry.Text = Estado;
            descripcionentry.Text = Descripcion;
            nitentry.Text = Nit.ToString();
            
		}

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            Datos.Contratista contratista = new Datos.Contratista()
            {
                id_contratista = IdContratista1,
                nombre = Nombre1,
                apellido_paterno = Apellidop1,
                apellido_materno = Apellidom1,
                telefono = Telefono1,
                direccion = Direccion1,
                foto = Foto1,
                cedula_identidad = Cedulaidentidad1,
                rubro = Rubro1,
                calificacion = Calififacion1,
                estado = Estadoo1,
                prioridad = Prioridad1,
                descripcion = Descripcion1,
                nit = Nit1,
                usuario = Usuario1,
                contrasena = Contrasena1,
            };
            var json = JsonConvert.SerializeObject(contratista);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/contratistas/editarContratista.php", content);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlert("Hey", "Se edito correctamente", "OK");
                Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Hey", result.StatusCode.ToString(), "Fale Ferga");
                Navigation.PopAsync();
            }
        }
    }
}
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
    public partial class ModificarServicio : ContentPage
    {
        private int IdServicio1;
        private string Nombre_Servicio1;
        private int Telefono1;
        private string Email1;
        private string Direccion1;
        private string Ubicacion_lat1;
        private string Ubicacion_long1;
        private string Foto1;
        private string Estado1;
        private int Nit1;
        private string Rubro1;
        private decimal Calififacion1;
        private int Prioridad1;
        private string Descripcion1;
        private string Usuario1;
        private string Contrasena1;

        public ModificarServicio(int IdServicio, string Nombre_servicio, int Telefono, string Email, string Direccion,
           string Ubicacion_lat, string Ubicacion_long, string Foto, string Estado, int Nit, string Rubro, decimal Calififacion, int Prioridad, string Descripcion,
           string Usuario, string Contrasena)
        {

            InitializeComponent();

            IdServicio1 = IdServicio;
            Nombre_Servicio1 = Nombre_servicio;
            Telefono1 = Telefono;
            Email1 = Email;
            Direccion1 = Direccion;
            Ubicacion_lat1 = Ubicacion_lat;
            Ubicacion_long1 = Ubicacion_long;
            Foto1 = Foto;
            Estado1 = Estado;
            Nit1 = Nit;
            Rubro1 = Rubro;
            Calififacion1 = Calififacion;
            Prioridad1 = Prioridad;
            Descripcion1 = Descripcion;
            Usuario1 = Usuario;
            Contrasena1 = Contrasena;


            nombreentry.Text = Nombre_servicio;
            telefonoentry.Text = Telefono.ToString();
            emailentry.Text = Email;
            estadoentry.Text = Estado;
            descripcionentry.Text = Descripcion;
            nitentry.Text = Nit.ToString();

        }

        private async void GuardarModificado_Clicked(object sender, EventArgs e)
        {
            Servicio servicio = new Servicio()
            {
                id_servicio = IdServicio1,
                nombre = nombreentry.Text,
                telefono = Convert.ToInt32(telefonoentry.Text),
                email = emailentry.Text,
                direccion = Direccion1,
                ubicacion_lat = Ubicacion_lat1,
                ubicacion_long = Ubicacion_long1,
                foto = Foto1,
                estado = estadoentry.Text,
                nit = Convert.ToInt32(nitentry.Text),
                rubro = Rubro1,
                calificacion = Calififacion1,
                prioridad = Prioridad1,
                descripcion = descripcionentry.Text,
                
                usuario = Usuario1,
                contrasena = Contrasena1


            };
            var json = JsonConvert.SerializeObject(servicio);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/servicios/editarServicio.php", content);

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
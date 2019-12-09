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
	public partial class ModificarProfesional : ContentPage
	{
        private int Id_Profesional1;
        private string Nombre_Profesional1;
        private string ApellidoP1;
        private string ApellidoM1;
        private int Telefono1;
        private string Email1;
        private string Direccion1;      
        private string Foto1;
        private string Cedula1;
        private string Rubro1;
        private decimal Calififacion1;
        private string Estado1;
        private int Prioridad1;
        private string Descripcion1;
        private int Nit1;
        private string Curriculum1;
        private string Usuario1;
        private string Contrasena1;

        public ModificarProfesional (int id_profesional, string nombre, string apellido_paterno, string apellido_materno, int telefono, string email,
            string direccion, string foto, string cedula_identidad, string rubro, decimal calificacion, string estado, int prioridad, string descripcion, int nit,   
           string curriculum, string usuario, string contrasena)
		{
			InitializeComponent ();

            Id_Profesional1 = id_profesional;
            Nombre_Profesional1 = nombre;
            ApellidoP1 = apellido_paterno;
            ApellidoM1 = apellido_materno;
            Telefono1 = telefono;
            Email1 = email;
            Direccion1 = direccion;
            Foto1 = foto;
            Cedula1 = cedula_identidad;
            Rubro1 = rubro;
            Calififacion1 = calificacion;
            Estado1 = estado;
            Prioridad1 = prioridad;
            Descripcion1 = descripcion;
            Nit1 = nit;
            Curriculum1 = curriculum;
            Usuario1 = usuario;
            Contrasena1 = contrasena;

            nombreentry.Text = nombre;
            apellidopEntry.Text = apellido_paterno;
            apellidomEntry.Text = apellido_materno;
            telefonoentry.Text = telefono.ToString();
            emailentry.Text = email;
            carnetentry.Text = cedula_identidad;
            estadoentry.Text = estado;
            descripcionentry.Text = descripcion;
            nitentry.Text = nit.ToString();

        }

        private async void GuardarModificado_Clicked(object sender, EventArgs e)
        {
            Profesional profesional = new Profesional()
            {
                id_profesional = Id_Profesional1,
                nombre = nombreentry.Text,
                apellido_paterno = apellidopEntry.Text,
                apellido_materno = apellidomEntry.Text,
                telefono = Convert.ToInt32(telefonoentry.Text),
                email = emailentry.Text,
                direccion = Direccion1,
                foto = Foto1,
                cedula_identidad = carnetentry.Text,
                rubro = Rubro1,
                calificacion = Calififacion1,
                estado = estadoentry.Text,
                prioridad = Prioridad1,
                descripcion = descripcionentry.Text,
                nit = Convert.ToInt32(nitentry.Text),
                curriculum = Curriculum1,
                usuario = Usuario1,
                contrasena = Contrasena1


            };
            var json = JsonConvert.SerializeObject(profesional);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/profesionales/editarProfesional.php", content);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlert("EDITAR", "Se edito correctamente", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR", result.StatusCode.ToString(), "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
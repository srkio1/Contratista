using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Contratista.Datos;
using Newtonsoft.Json;
using System.Net.Http;

namespace Contratista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PerfilContratista : ContentPage
	{
        private string queryrubro;
        int Numero_telefono = 0;
        private string NombreC;
        private int IDContratista;
        public PerfilContratista(int id_contratista, string nombre, string apellido_paterno, string apellido_materno, int telefono, string foto,
                                 string rubro, decimal calificacion, string descripcion)
        {
            InitializeComponent();
            IDContratista = id_contratista;
            NombreC = nombre + " " + apellido_paterno + " " + apellido_materno;
            queryrubro = rubro;
            Numero_telefono = telefono;
            nombretxt.Text = nombre + " " + apellido_paterno + " " + apellido_materno;
            txtdescripcion.Text = descripcion;
            imgPerfil.Source = "http://dmrbolivia.online" + foto;
            txtTelefono.Text = telefono.ToString();
            califtxt.Text = calificacion.ToString();
            rubrotxt.Text = rubro;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarCalificacion(NombreC, IDContratista));
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open(Numero_telefono.ToString());
            }
            catch (Exception err)
            {
                await DisplayAlert("Error", "Algo salio mal, intentalo de nuevo", "OK");
                ReportesLogs reportesLogs = new ReportesLogs()
                {
                    descripcion = err.ToString(),
                    fecha = DateTime.Now.ToLocalTime()
                };
                var json = JsonConvert.SerializeObject(reportesLogs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarReporteLog.php", content);
            }
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                Datos.Chat.Open("+591" + Numero_telefono, " ");
            }
            catch (Exception err)
            {
                await DisplayAlert("Error", "Algo salio mal, intentalo de nuevo", "OK");
                ReportesLogs reportesLogs = new ReportesLogs()
                {
                    descripcion = err.ToString(),
                    fecha = DateTime.Now.ToLocalTime()
                };
                var json = JsonConvert.SerializeObject(reportesLogs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarReporteLog.php", content);
            }
        }
    }
}
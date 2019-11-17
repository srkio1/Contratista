using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;

namespace Contratista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaProfesional : ContentPage
	{
        private string queryrubro;
        public ListaProfesional(string rubro)
        {
            InitializeComponent();
            queryrubro = rubro;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                HttpClient client = new HttpClient();
                if (queryrubro == "Ingeniero civil")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/profesionales/querys/listaIngenieroCivil.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Datos.Profesional>>(result);
                    listaProfesionales.ItemsSource = usuarios;
                }
                else if (queryrubro == "Arquitecto")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/profesionales/querys/listaArquitecto.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Datos.Profesional>>(result);
                    listaProfesionales.ItemsSource = usuarios;
                }
                else if (queryrubro == "Ingeniero electrico")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/profesionales/querys/listaIngenieroElectrico.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Datos.Profesional>>(result);
                    listaProfesionales.ItemsSource = usuarios;
                }
                else if (queryrubro == "Topografo")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/profesionales/querys/listaTopografo.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Datos.Profesional>>(result);
                    listaProfesionales.ItemsSource = usuarios;
                }
                else if (queryrubro == "Calculista")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/profesionales/querys/listaCalculista.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Datos.Profesional>>(result);
                    listaProfesionales.ItemsSource = usuarios;
                }
                else if (queryrubro == "Ingeniero hidraulico")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/profesionales/querys/listaIngenieroHidraulico.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Datos.Profesional>>(result);
                    listaProfesionales.ItemsSource = usuarios;
                }
                else if (queryrubro == "Cadista")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/profesionales/querys/listaCadista.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Datos.Profesional>>(result);
                    listaProfesionales.ItemsSource = usuarios;
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("ERROR", err.ToString(), "OK");
            }
        }

        private async void ListaProfesionales_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Datos.Profesional;
            await Navigation.PushAsync(new PerfilProfesional(detalles.id_profesional, detalles.nombre, detalles.apellido_paterno,
                detalles.apellido_materno, detalles.telefono, detalles.email, detalles.direccion, detalles.foto, detalles.cedula_identidad,
                detalles.rubro, detalles.calificacion, detalles.estado, detalles.prioridad, detalles.descripcion, detalles.nit, detalles.curriculum));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Contratista.Datos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaServicio : ContentPage
	{
        private string queryrubro;
        public ListaServicio(string rubro)
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
                if (queryrubro == "Alquiler de maquinaria")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/servicios/querys/listaAlquilerdeMaquinaria.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Servicio>>(result);
                    listaServicios.ItemsSource = usuarios;
                }
                else if (queryrubro == "Alquiler de equipos")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/servicios/querys/listaAlquilerdeEquipos.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Servicio>>(result);
                    listaServicios.ItemsSource = usuarios;
                }
                else if (queryrubro == "Alquiler de herramientas")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/servicios/querys/listaAlquilerdeHerramientas.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Servicio>>(result);
                    listaServicios.ItemsSource = usuarios;
                }
                else if (queryrubro == "Transporte")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/servicios/querys/listaTransporte.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Servicio>>(result);
                    listaServicios.ItemsSource = usuarios;
                }
                else if (queryrubro == "Alquiler de vehiculos")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/servicios/querys/listaAlquilerdeVehiculos.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Servicio>>(result);
                    listaServicios.ItemsSource = usuarios;
                }
                else if (queryrubro == "Mantenimiento")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/servicios/querys/listaMantenimiento.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Servicio>>(result);
                    listaServicios.ItemsSource = usuarios;
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("ERROR", err.ToString(), "OK");
            }
        }
        private async void ListaServicios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Servicio;
            await Navigation.PushAsync(new PerfilServicio(detalles.id_servicio, detalles.nombre, detalles.telefono, detalles.email,
                detalles.direccion, detalles.ubicacion_lat, detalles.ubicacion_long, detalles.foto, detalles.nit, detalles.rubro,
                detalles.calificacion, detalles.descripcion));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratista.Datos;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaMaterial : ContentPage
    {
        private string queryrubro;
        public ListaMaterial(string rubro)
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
                if (queryrubro == "Ferreteria")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/materiales/querys/listaFerreteria.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Material>>(result);
                    listaMateriales.ItemsSource = usuarios;
                }
                else if (queryrubro == "Barraca")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/materiales/querys/listaBarraca.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Material>>(result);
                    listaMateriales.ItemsSource = usuarios;
                }
                else if (queryrubro == "Cemento")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/materiales/querys/listaCemento.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Material>>(result);
                    listaMateriales.ItemsSource = usuarios;
                }
                else if (queryrubro == "Agregados")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/materiales/querys/listaAgregados.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Material>>(result);
                    listaMateriales.ItemsSource = usuarios;
                }
                else if (queryrubro == "Vidrieria")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/materiales/querys/listaVidrieria.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Material>>(result);
                    listaMateriales.ItemsSource = usuarios;
                }
                else if (queryrubro == "Ceramica")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/materiales/querys/listaCeramica.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Material>>(result);
                    listaMateriales.ItemsSource = usuarios;
                }
                else if (queryrubro == "Ladrillo")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/materiales/querys/listaLadrillo.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Material>>(result);
                    listaMateriales.ItemsSource = usuarios;
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("ERROR", err.ToString(), "OK");
            }
        }

        private async void ListaMateriales_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Material;
            await Navigation.PushAsync(new PerfilMaterial(detalles.id_material, detalles.nombre, detalles.telefono, detalles.email,
                detalles.direccion, detalles.ubicacion_lat, detalles.ubicacion_long, detalles.foto, detalles.nit, detalles.rubro,
                detalles.calificacion, detalles.descripcion));
        }
    }
}
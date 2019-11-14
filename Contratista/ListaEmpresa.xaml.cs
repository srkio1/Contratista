using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Contratista.Datos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaEmpresa : ContentPage
	{
        private string queryrubro;
        public ListaEmpresa(string rubro)
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
                if (queryrubro == "Constructora")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/empresas/querys/listaConstructora.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Empresa>>(result);
                    listaEmpresas.ItemsSource = usuarios;
                }
                else if (queryrubro == "Diseno")
                {
                    var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/empresas/querys/listaDiseno.php");
                    string result = await client.GetStringAsync(url_contratista);
                    var usuarios = JsonConvert.DeserializeObject<List<Empresa>>(result);
                    listaEmpresas.ItemsSource = usuarios;
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("ERROR", err.ToString(), "OK");
            }
        }

        private async void ListaEmpresas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Empresa;
            await Navigation.PushAsync(new PerfilEmpresa(detalles.id_empresa, detalles.nombre, detalles.telefono, detalles.email,
                detalles.direccion, detalles.ubicacion_lat, detalles.ubicacion_long, detalles.foto, detalles.rubro, detalles.calificacion,
                detalles.descripcion));
        }
    }
}
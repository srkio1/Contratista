using Contratista.Datos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Busqueda : ContentPage
    {
        private string TxtBuscado;
        List<Datos.Contratista> Items;
        public Busqueda(string TextoBuscador)
        {
            InitializeComponent();
            TxtBuscado = TextoBuscador;
            sb_search.Text = TextoBuscador;
            InitList();
            InitSearchBar();
        }

        async void InitList()
        {
            Items = new List<Datos.Contratista>();

            try
            {
                HttpClient client = new HttpClient();
                var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/contratistas/listaContratista.php");
                string result = await client.GetStringAsync(url_contratista);
                var usuarios = JsonConvert.DeserializeObject<List<Datos.Contratista>>(result);

                foreach (var item in usuarios.Distinct())
                {
                    Items.Add(new Datos.Contratista
                    {
                        nombre = item.nombre,
                        id_contratista = item.id_contratista,
                        apellido_paterno = item.apellido_paterno,
                        apellido_materno = item.apellido_materno,
                        telefono = item.telefono,
                        direccion = item.direccion,
                        foto = item.foto,
                        rubro = item.rubro,
                        calificacion = item.calificacion,
                        descripcion = item.descripcion
                    });
                }
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
            if (TxtBuscado == null)
            {
                listSearch.ItemsSource = Items;
            }
            else
            {
                listSearch.ItemsSource = Items.Where(x => x.rubro.ToLower().Contains(TxtBuscado.ToLower()) || x.descripcion.ToLower().Contains(TxtBuscado.ToLower()));
            }
        }

        void InitSearchBar()
        {
            sb_search.TextChanged += (s, e) => FilterItem(sb_search.Text);
            sb_search.SearchButtonPressed += (s, e) => FilterItem(sb_search.Text);
        }

        private void FilterItem(string filter)
        {
            listSearch.BeginRefresh();

            if (string.IsNullOrWhiteSpace(filter))
            {
                listSearch.ItemsSource = Items;
            }
            else if (string.IsNullOrEmpty(filter))
            {
                listSearch.ItemsSource = Items;
            }
            else
            {
                listSearch.ItemsSource = Items.Where(x => x.rubro.ToLower().Contains(filter.ToLower()) || x.descripcion.ToLower().Contains(filter.ToLower()));
            }
            listSearch.EndRefresh();
        }

        private async void ListSearch_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Datos.Contratista;
            await Navigation.PushAsync(new PerfilContratista(detalles.id_contratista, detalles.nombre,
                                                         detalles.apellido_paterno, detalles.apellido_materno,
                                                         detalles.telefono, detalles.foto, detalles.rubro,
                                                         detalles.calificacion, detalles.descripcion));
        }
    }
}
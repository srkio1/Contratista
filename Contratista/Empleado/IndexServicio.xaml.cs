using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contratista.Datos;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Contratista.Empleado;

namespace Contratista.Empleado
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IndexServicio : TabbedPage
	{
        int idServicio = 0;
        string Nombre;
        ObservableCollection<Catalogo> catalogos = new ObservableCollection<Catalogo>();
        public ObservableCollection<Catalogo> Catalogos { get { return catalogos; } }
        public IndexServicio(int id_servicio, string nombre, int telefono, string email, string rubro, string estado, int prioridad, decimal calificacion, string foto,
                               string descripcion, int nit)
        {
            InitializeComponent();
            idServicio = id_servicio;
            Nombre = nombre;
            txtNombre.Text = nombre;
            txtTelefono.Text = telefono.ToString();
            txtEmail.Text = email;
            txtRubro.Text = rubro;
            txtEstado.Text = estado;
            txtPrioridad.Text = prioridad.ToString();
            txtNit.Text = nit.ToString();
            txtDescripcion.Text = descripcion;
            img_perfil.Source = "http://dmrbolivia.online" + foto;
            GetCatalogo();
        }

        private async void ListPortafolios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Catalogo;
            await Navigation.PushAsync(new VercatalogoServicio(detalles.id_catalogo, detalles.nombre, detalles.imagen_1, detalles.imagen_2, detalles.descripcion, detalles.id_servicio));


        }
        private async void GetCatalogo()
        {

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/catalogos/listaCatalogo.php");
            var catalogosss = JsonConvert.DeserializeObject<List<Catalogo>>(response);
            try
            {


                foreach (var item in catalogosss.Distinct())
                {
                    if (item.id_servicio == idServicio)
                    {
                        catalogos.Add(new Catalogo

                        {
                            id_catalogo = item.id_catalogo,
                            nombre = item.nombre,
                            imagen_1 = item.imagen_1,
                            imagen_2 = item.imagen_2,
                            descripcion = item.descripcion
                        });
                    }
                }
            }

            catch (Exception err)
            {
                await DisplayAlert("ERROR", err.ToString(), "OK");
            }
            listPortafolios.ItemsSource = catalogosss.Distinct();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarPromoServicio( idServicio , Nombre));
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Contratista.Datos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Contratista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PerfilServicio : TabbedPage
	{
        StackLayout stk1 = new StackLayout();


        int Numero_telefono = 0;
        private string queryrubro;
        private int idServicio;
        private string Latitud;
        private string Longitud;
       private string NombreServicio;
        
        ObservableCollection<Catalogo> catalogos = new ObservableCollection<Catalogo>();
        public ObservableCollection<Catalogo> Catalogos { get { return catalogos; } }
        public PerfilServicio(int id_servicio, string nombre, int telefono, string email, string direccion, string ubicacion_lat, string ubicacion_long,
            string foto, int nit, string rubro, decimal calificacion, string descripcion)
        {
            InitializeComponent();
            NombreServicio = nombre;
            Latitud = ubicacion_lat;
            Longitud = ubicacion_long;
            queryrubro = rubro;
            Numero_telefono = telefono;
            idServicio = id_servicio;
            nombretxt.Text = nombre;
            rubrotxt.Text = rubro;
            imgPerfil.Source = "http://dmrbolivia.online" + foto;
            txtdescripcion.Text = descripcion;
            txtTelefono.Text = telefono.ToString();
            califtxt.Text = calificacion.ToString();
            txtDireccion.Text = direccion;
            txtEmail.Text = email;
            GetCatalogo();
            GetPromo();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarCalificacionServicio(idServicio, NombreServicio));
        }

        private async void GetCatalogo()
        {
            stk1.HeightRequest = 200;
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
                await DisplayAlert("Error", "Algo salio mal, intentalo de nuevo", "OK");
                ReportesLogs reportesLogs = new ReportesLogs()
                {
                    descripcion = err.ToString(),
                    fecha = DateTime.Now.ToLocalTime()
                };
                var json = JsonConvert.SerializeObject(reportesLogs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client1 = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarReporteLog.php", content);
            }
            listacatalogo.ItemsSource = catalogos.Distinct();
        }
        private async void Listacatalogo_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Catalogo;
            await Navigation.PushAsync(new Vercatalogo(detalles.id_catalogo, detalles.nombre, detalles.imagen_1,
                detalles.imagen_2, detalles.descripcion));
        }
        private async void BtnIrDireccion_Clicked(object sender, EventArgs e)
        {
            try
            {
                var location = new Location(Convert.ToDouble(Latitud), Convert.ToDouble(Longitud));
                var options = new MapLaunchOptions { Name = nombretxt.Text };
                await Map.OpenAsync(location, options); ;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild", ex.Message, "OK");
            }
        }
        private async void GetPromo()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/promociones/listaPromocionServicio.php");
                var listpromo = JsonConvert.DeserializeObject<List<Promocion_servicios>>(response);

                foreach (var item in listpromo.Distinct())
                {
                    if (item.id_servicio == idServicio)
                    {
                        StackLayout stk1 = new StackLayout();
                        stk1.BackgroundColor = Color.LightGray;
                        stkPromoActiva.Children.Add(stk1);

                        Label txtNombre = new Label();
                        txtNombre.Text = item.nombre;
                        txtNombre.TextColor = Color.Black;
                        txtNombre.FontSize = 30;
                        stk1.Children.Add(txtNombre);

                        Image img = new Image();
                        img.Source = "http://dmrbolivia.online" + item.imagen;
                        img.HeightRequest = 200;
                        img.Aspect = Aspect.AspectFit;
                        img.HorizontalOptions = LayoutOptions.CenterAndExpand;
                        stk1.Children.Add(img);

                        Label txtDesc = new Label();
                        txtDesc.Text = item.descripcion;
                        txtDesc.FontSize = 15;
                        txtDesc.TextColor = Color.Black;
                        stk1.Children.Add(txtDesc);

                        BoxView bv = new BoxView();
                        bv.HeightRequest = 5;
                        bv.Color = Color.Gray;
                    }
                }
            }
            catch (Exception erro)
            {
                Console.Write("EEERRROOOORRR= " + erro);
            }
        }
        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open(Numero_telefono.ToString());
            }
            catch (Exception err)
            {
                await DisplayAlert("ERROR", err.ToString(), "OK");
            }
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                Chat.Open("+591" + Numero_telefono, " ");
            }
            catch (Exception err)
            {
                await DisplayAlert("Error", err.Message, "OK");
            }
        }
    }
}
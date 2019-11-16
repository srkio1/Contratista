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
            GetPromo();
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

                var response2 = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/promociones/listaPromocionServicioInactiva.php");
                var listpromo2 = JsonConvert.DeserializeObject<List<Promocion_servicios>>(response2);

                foreach (var item in listpromo2.Distinct())
                {
                    if (item.id_servicio == idServicio)
                    {
                        StackLayout stk2 = new StackLayout();
                        stkPromoInactiva.Children.Add(stk2);

                        Label txtNombre = new Label();
                        txtNombre.Text = item.nombre;
                        txtNombre.TextColor = Color.Black;
                        txtNombre.FontSize = 20;
                        stk2.Children.Add(txtNombre);

                        Image img = new Image();
                        img.Source = "http://dmrbolivia.online" + item.imagen;
                        img.HeightRequest = 200;
                        img.Aspect = Aspect.AspectFit;
                        img.HorizontalOptions = LayoutOptions.CenterAndExpand;
                        stk2.Children.Add(img);

                        Label txtDesc = new Label();
                        txtDesc.Text = item.descripcion;
                        txtDesc.FontSize = 15;
                        txtDesc.TextColor = Color.Black;
                        stk2.Children.Add(txtDesc);
                    }
                }
            }

            catch (Exception erro)
            {
                Console.Write("EEERRROOOORRR= " + erro);
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
	public partial class IndexMaterial : TabbedPage
	{
        private int idMaterial;
        private string nombre_material;
        ObservableCollection<Productos> producto = new ObservableCollection<Productos>();
        public ObservableCollection<Productos> productos { get { return producto; } }
        public IndexMaterial(int id_material, string nombre, int telefono, string email, string rubro, int prioridad, decimal calificacion, string foto, string descripcion,
                            int nit)
        {
            InitializeComponent();
            GetInfo();
            GetPromo();
            nombre_material = nombre;
            idMaterial = id_material;
            txtNombre.Text = nombre;
            txtTelefono.Text = telefono.ToString();
            txtEmail.Text = email;
            txtRubro.Text = rubro;
            txtPrioridad.Text = prioridad.ToString();
            txtDescripcion.Text = descripcion;
            txtNit.Text = nit.ToString();
            img_perfil.Source = "http://dmrbolivia.online" + foto;
        }

        private async void ListPortafolios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           
        }

        private async void ListaProducto_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Productos;
            await Navigation.PushAsync(new VerProducto(detalles.id_producto, detalles.nombre, detalles.descripcion, detalles.imagen_1,
                detalles.imagen_2, detalles.id_material));
        }
        private async void GetInfo()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/productos/listaProducto.php");
                var product = JsonConvert.DeserializeObject<List<Productos>>(response);

                foreach (var item in product.Distinct())
                {
                    if (item.id_material == idMaterial)
                    {
                        productos.Add(new Productos
                        {
                            nombre = item.nombre,
                            id_producto = item.id_producto,
                            imagen_1 = item.imagen_1,
                            imagen_2 = item.imagen_2,
                            descripcion = item.descripcion
                        });
                    }
                }
            }

            catch (Exception erro)
            {
                Console.Write("EEERRROOOORRR= " + erro);
            }
            listaProducto.ItemsSource = productos.Distinct();
        }
        private async void GetPromo()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/promociones/listaPromocionMaterial.php");
                var listpromo = JsonConvert.DeserializeObject<List<Promocion_material>>(response);

                foreach (var item in listpromo.Distinct())
                {
                    if (item.id_material == idMaterial)
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

                var response2 = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/promociones/listaPromocionMaterialInactiva.php");
                var listpromo2 = JsonConvert.DeserializeObject<List<Promocion_material>>(response2);

                foreach (var item in listpromo2.Distinct())
                {
                    if (item.id_material == idMaterial)
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarPromoMaterial( idMaterial , nombre_material));
        }
    }
}
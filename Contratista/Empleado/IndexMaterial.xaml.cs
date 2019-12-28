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
        private int IdMaterial;
        private string Nombre_material;
        private int Telefono;
        private string Email;
        private string Direccion;
        private string Ubicacion_lat;
        private string Ubicacion_long;
        private string Foto;
        private int Nit;
        private string Rubro;
        private decimal Calififacion;
        private int Prioridad;
        private string Descripcion;
        private string Usuario;
        private string Contrasena;
        ObservableCollection<Productos> producto = new ObservableCollection<Productos>();
        public ObservableCollection<Productos> productos { get { return producto; } }
        public IndexMaterial(int id_material, string nombre, int telefono, string email, string direccion, string ubicacion_lat, string ubicacion_long,
             string foto, int nit, string rubro, decimal calificacion, int prioridad, string descripcion, string usuario, string contrasena)
        {
            InitializeComponent();
            IdMaterial = id_material;
            Nombre_material = nombre;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            Ubicacion_lat = ubicacion_lat;
            Ubicacion_long = ubicacion_long;
            Foto = foto;
            Nit = nit;
            Rubro = rubro;
            Calififacion = calificacion;
            Prioridad = prioridad;
            Descripcion = descripcion;
            Usuario = usuario;
            Contrasena = contrasena;
            Nombre_material = nombre;
            IdMaterial = id_material;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            productos.Clear();
            stkPromoActiva.Children.Clear();
            stkPromoInactiva.Children.Clear();
            GetInfo();
            GetPromo();
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
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/materiales/listaMaterial.php");
                var materials = JsonConvert.DeserializeObject<List<Material>>(response);

                foreach (var item in materials.Distinct())
                {
                    if (item.id_material == IdMaterial)
                    {
                        txtNombre.Text = item.nombre;
                        txtTelefono.Text = item.telefono.ToString();
                        txtEmail.Text = item.email;
                        txtRubro.Text = item.rubro;
                        txtPrioridad.Text = item.prioridad.ToString();
                        txtDescripcion.Text = item.descripcion;
                        txtNit.Text = item.nit.ToString();
                        img_perfil.Source = "http://dmrbolivia.online" + item.foto;
                    }
                }
            }

            catch (Exception erro)
            {
                await DisplayAlert("Error", "Algo salio mal, intentalo de nuevo", "OK");
                ReportesLogs reportesLogs = new ReportesLogs()
                {
                    descripcion = erro.ToString(),
                    fecha = DateTime.Now.ToLocalTime()
                };
                var json = JsonConvert.SerializeObject(reportesLogs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarReporteLog.php", content);
            }

            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/productos/listaProducto.php");
                var product = JsonConvert.DeserializeObject<List<Productos>>(response);

                foreach (var item in product.Distinct())
                {
                    if (item.id_material == IdMaterial)
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
                await DisplayAlert("Error", "Algo salio mal, intentalo de nuevo", "OK");
                ReportesLogs reportesLogs = new ReportesLogs()
                {
                    descripcion = erro.ToString(),
                    fecha = DateTime.Now.ToLocalTime()
                };
                var json = JsonConvert.SerializeObject(reportesLogs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarReporteLog.php", content);
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
                try {
                    foreach (var item in listpromo.Distinct())
                    {
                        if (item.id_material == IdMaterial)
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

                            Button btnEditar = new Button();
                            btnEditar.Text = "EDITAR PROMOCION";
                            btnEditar.HorizontalOptions = LayoutOptions.FillAndExpand;
                            btnEditar.BackgroundColor = Color.Yellow;
                            btnEditar.TextColor = Color.Black;
                            btnEditar.Clicked += async (sender, args) => await Navigation.PushAsync(new EditarPromocionMaterial(item.id_material, item.nombre, item.estado, item.descripcion, item.imagen, item.id_promocion_m));
                            stk1.Children.Add(btnEditar);

                            BoxView bv = new BoxView();
                            bv.HeightRequest = 5;
                            bv.Color = Color.Black;
                            stk1.Children.Add(bv);
                        }
                    }

                    var response2 = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/promociones/listaPromocionMaterialInactiva.php");
                    var listpromo2 = JsonConvert.DeserializeObject<List<Promocion_material>>(response2);

                    foreach (var item in listpromo2.Distinct())
                    {
                        if (item.id_material == IdMaterial)
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

                            Button btnEditar = new Button();
                            btnEditar.Text = "EDITAR PROMOCION";
                            btnEditar.HorizontalOptions = LayoutOptions.FillAndExpand;
                            btnEditar.BackgroundColor = Color.Yellow;
                            btnEditar.TextColor = Color.Black;
                            btnEditar.Clicked += async (sender, args) => await Navigation.PushAsync(new EditarPromocionMaterial(item.id_material, item.nombre, item.estado, item.descripcion, item.imagen, item.id_promocion_m));
                            stk2.Children.Add(btnEditar);

                            BoxView bv = new BoxView();
                            bv.HeightRequest = 5;
                            bv.Color = Color.Black;
                            stk2.Children.Add(bv);
                        }
                    }
                }
                catch (Exception erro)
                { }
            }
          

            catch (Exception erro)
            {
                await DisplayAlert("Error", "Algo salio mal, intentalo de nuevo", "OK");
                ReportesLogs reportesLogs = new ReportesLogs()
                {
                    descripcion = erro.ToString(),
                    fecha = DateTime.Now.ToLocalTime()
                };
                var json = JsonConvert.SerializeObject(reportesLogs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarReporteLog.php", content);
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarPromoMaterial(IdMaterial, Nombre_material));
        }

        private void Modificar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModificarMaterial(IdMaterial, Nombre_material, Telefono, Email, Direccion, Ubicacion_lat, Ubicacion_long, Foto,
                          Nit, Rubro, Calififacion, Prioridad, Descripcion, Usuario, Contrasena));
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Alert", "Quiere Cerrar Sesion", "Si", "No");
                if (result) await this.Navigation.PushAsync(new Index());
            });
            return true;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarProducto(IdMaterial, Nombre_material));
        }
    }
}
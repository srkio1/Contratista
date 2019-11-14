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
	public partial class VerProducto : ContentPage
	{
        private int IdProducto;
        private string Nombre;
        private string Descripcion;
        private string Imagen1;
        private string Imagen2;
        private int IdMaterial;
        public VerProducto(int id_producto, string nombre, string descripcion, string imagen_1, string imagen_2, int id_material)
        {
            InitializeComponent();

            IdProducto = id_producto;
            Nombre = nombre;
            Descripcion = descripcion;
            Imagen1 = imagen_1;
            Imagen2 = imagen_2;
            IdMaterial = id_material;
            GetProducto();

        }

        private async void GetProducto()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/productos/listaProducto.php");
                var product = JsonConvert.DeserializeObject<List<Productos>>(response);
                foreach (var item in product.Distinct())
                {
                    if (item.id_producto == IdProducto)
                    {
                        StackLayout stk1 = new StackLayout();
                        stk1.Orientation = StackOrientation.Horizontal;
                        stkMain.Children.Add(stk1);

                        Label txtNomb = new Label();
                        txtNomb.Text = item.nombre;
                        txtNomb.FontSize = 30;
                        txtNomb.TextColor = Color.White;
                        txtNomb.FontAttributes = FontAttributes.Bold;
                        stk1.Children.Add(txtNomb);

                        StackLayout stk2 = new StackLayout();
                        stk2.Orientation = StackOrientation.Horizontal;
                        stkMain.Children.Add(stk2);

                        StackLayout stk21 = new StackLayout();
                        stk2.Children.Add(stk21);

                        StackLayout stk22 = new StackLayout();
                        stk2.Children.Add(stk22);

                        Image img1 = new Image();
                        img1.Source = "http://dmrbolivia.online" + item.imagen_1;
                        img1.Aspect = Aspect.AspectFit;
                        img1.HeightRequest = 200;
                        stk21.Children.Add(img1);

                        Image img2 = new Image();
                        img2.Source = "http://dmrbolivia.online" + item.imagen_2;
                        img2.Aspect = Aspect.AspectFit;
                        img2.HeightRequest = 200;
                        stk22.Children.Add(img2);

                        StackLayout stkDesc = new StackLayout();
                        stkDesc.HorizontalOptions = LayoutOptions.FillAndExpand;
                        stkMain.Children.Add(stkDesc);

                        Label txtDescr = new Label();
                        txtDescr.Text = item.descripcion;
                        txtDescr.HorizontalOptions = LayoutOptions.FillAndExpand;
                        txtDescr.TextColor = Color.White;
                        stkDesc.Children.Add(txtDescr);
                    }
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("ERROR", err.ToString(), "OK");
            }
        }
    }
}
using Contratista.Datos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista.Empleado
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarProducto : ContentPage
	{
        private int IDProducto;
        private string IMG1;
        private string IMG2;
        private int IDMaterial;
		public EditarProducto (int IdProducto, string Nombre, string Imagen1, string Imagen2, string Descripcion, int IdMaterial)
		{
			InitializeComponent ();
            IDProducto = IdProducto;
            IMG1 = Imagen1;
            IMG2 = Imagen2;
            txtDescripcion.Text = Descripcion;
            txtNombre.Text = Nombre;
            IDMaterial = IdMaterial;
		}
        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Productos productossss = new Productos()
                {
                    id_producto = IDProducto,
                    imagen_1 = IMG1,
                    imagen_2 = IMG2,
                    descripcion = txtDescripcion.Text,
                    nombre = txtNombre.Text,
                    id_material = IDMaterial
                };

                var json = JsonConvert.SerializeObject(productossss);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/productos/editarProducto.php", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("EDITAR", "Se edito correctamente", "OK");
                    await Navigation.PopAsync(true);
                }
                else
                {
                    await DisplayAlert("ERROR", result.StatusCode.ToString(), "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("ERROR", err.ToString(), "OK");
            }
        }

        private async void BtnBorrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Productos productos = new Productos()
                {
                    id_producto = IDProducto,
                    imagen_1 = IMG1,
                    imagen_2 = IMG2,
                    descripcion = txtDescripcion.Text,
                    nombre = txtNombre.Text,
                    id_material = IDMaterial
                };

                var json = JsonConvert.SerializeObject(productos);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/productos/borrarProducto.php", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("EDITAR", "Se borro correctamente", "OK");
                    await Navigation.PopAsync(true);
                }
                else
                {
                    await DisplayAlert("ERROR", result.StatusCode.ToString(), "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("ERROR", err.ToString(), "OK");
            }
        }
    }
}
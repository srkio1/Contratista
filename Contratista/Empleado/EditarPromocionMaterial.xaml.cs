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
	public partial class EditarPromocionMaterial : ContentPage
	{
        private int IDPromo;
        private int IDMaterial;
        private string ImagenS;
        public EditarPromocionMaterial (int id, string nombre, string estado, string descripcion, string imagen, int id_promocion_m)
		{
			InitializeComponent ();
            txtNombre.Text = nombre;
            txtDescripcion.Text = descripcion;
            IDPromo = id_promocion_m;
            IDMaterial = id;
            ImagenS = imagen;
        }
        private string estadopick;
        private void Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectIndex = picker.SelectedIndex;
            if (selectIndex != -1)
            {
                estadopick = picker.Items[selectIndex];
            }
        }
        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Promocion_material promocion_Material = new Promocion_material()
                {
                    id_promocion_m = IDPromo,
                    nombre = txtNombre.Text,
                    estado = estadopick,
                    imagen = ImagenS,
                    descripcion = txtDescripcion.Text,
                    id_material = IDMaterial
                };

                var json = JsonConvert.SerializeObject(promocion_Material);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/promociones/editarPromoMaterial.php", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("EDITAR", "Se edito correctamente", "OK");
                    await Navigation.PopAsync();
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
                Promocion_material promocion_Material = new Promocion_material()
                {
                    id_promocion_m = IDPromo,
                    nombre = txtNombre.Text,
                    estado = estadopick,
                    imagen = ImagenS,
                    descripcion = txtDescripcion.Text,
                    id_material = IDMaterial
                };

                var json = JsonConvert.SerializeObject(promocion_Material);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/promociones/borrarPromoMaterial.php", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("BORRAR", "Se elimino correctamente", "OK");
                    await Navigation.PopAsync();
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
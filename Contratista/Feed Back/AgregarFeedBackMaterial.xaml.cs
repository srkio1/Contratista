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

namespace Contratista.Feed_Back
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgregarFeedBackMaterial : ContentPage
	{
        private int ID_Material;
		public AgregarFeedBackMaterial (int IdMaterial)
		{
			InitializeComponent ();
            ID_Material = IdMaterial;
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Feedback_material feedback_Material = new Feedback_material()
                {
                    nombre = nombrepick,
                    descripcion = txtDescripcion.Text,
                    id_materiales = ID_Material
                };

                var json = JsonConvert.SerializeObject(feedback_Material);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();

                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/feed_back/agregarFeedBackMaterial.php", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("ENVIADO", "Se envio correctamente", "OK");
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
        }
        private string nombrepick;
        private void PickNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectIndex = picker.SelectedIndex;
            if (selectIndex != -1)
            {
                nombrepick = picker.Items[selectIndex];
            }
        }
    }
}
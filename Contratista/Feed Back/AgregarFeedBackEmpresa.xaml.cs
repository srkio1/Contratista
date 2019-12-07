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
	public partial class AgregarFeedBackEmpresa : ContentPage
	{
        public int ID_Empresa;
		public AgregarFeedBackEmpresa (int IdEmpresa)
		{
			InitializeComponent ();
            ID_Empresa = IdEmpresa;
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Feedback_empresa feedback_Empresa = new Feedback_empresa()
                {
                    nombre = nombrepick,
                    descripcion = txtDescripcion.Text,
                    id_empresas = ID_Empresa
                };

                var json = JsonConvert.SerializeObject(feedback_Empresa);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();

                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/feed_back/agregarFeedBackEmpresa.php", content);

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
                await DisplayAlert("ERROR", err.ToString(), "OK");
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
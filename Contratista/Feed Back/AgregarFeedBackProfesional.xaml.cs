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
	public partial class AgregarFeedBackProfesional : ContentPage
	{
        private int ID_Profesional;
		public AgregarFeedBackProfesional (int IdProfesional)
		{
			InitializeComponent ();
            ID_Profesional = IdProfesional;
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Feedback_profesional feedback_Profesional = new Feedback_profesional()
                {
                    nombre = nombrepick,
                    descripcion = txtDescripcion.Text,
                    id_profesional = ID_Profesional
                };

                var json = JsonConvert.SerializeObject(feedback_Profesional);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();

                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/feed_back/agregarFeedBackProfesional.php", content);

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
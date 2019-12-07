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

namespace Contratista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgregarCalificacionServicio : ContentPage
	{
        private decimal Calificacion;
        private int Id_Servicio;
        private string Telefono;
        public AgregarCalificacionServicio (int idServicio, string NombreServicio)
		{
			InitializeComponent ();
            Id_Servicio = idServicio;
            txtNombre.Text = NombreServicio;
            btnGuardar.Text = "CALIFICAR";
        }
        private void Star1_Clicked(object sender, EventArgs e)
        {
            Calificacion = 1;
            btnGuardar.Text = "Calificar con " + Calificacion + " estrellas";
            star1.Source = "icon_star_calificacion.png";
            star2.Source = "icon_star_calificacion_vacia.png";
            star3.Source = "icon_star_calificacion_vacia.png";
            star4.Source = "icon_star_calificacion_vacia.png";
            star5.Source = "icon_star_calificacion_vacia.png";
        }

        private void Star2_Clicked(object sender, EventArgs e)
        {
            Calificacion = 2;
            btnGuardar.Text = "Calificar con " + Calificacion + " estrellas";
            star1.Source = "icon_star_calificacion.png";
            star2.Source = "icon_star_calificacion.png";
            star3.Source = "icon_star_calificacion_vacia.png";
            star4.Source = "icon_star_calificacion_vacia.png";
            star5.Source = "icon_star_calificacion_vacia.png";
        }

        private void Star3_Clicked(object sender, EventArgs e)
        {
            Calificacion = 3;
            btnGuardar.Text = "Calificar con " + Calificacion + " estrellas";
            star1.Source = "icon_star_calificacion.png";
            star2.Source = "icon_star_calificacion.png";
            star3.Source = "icon_star_calificacion.png";
            star4.Source = "icon_star_calificacion_vacia.png";
            star5.Source = "icon_star_calificacion_vacia.png";
        }

        private void Star4_Clicked(object sender, EventArgs e)
        {
            Calificacion = 4;
            btnGuardar.Text = "Calificar con " + Calificacion + " estrellas";
            star1.Source = "icon_star_calificacion.png";
            star2.Source = "icon_star_calificacion.png";
            star3.Source = "icon_star_calificacion.png";
            star4.Source = "icon_star_calificacion.png";
            star5.Source = "icon_star_calificacion_vacia.png";
        }

        private void Star5_Clicked(object sender, EventArgs e)
        {
            Calificacion = 5;
            btnGuardar.Text = "Calificar con " + Calificacion + " estrellas";
            star1.Source = "icon_star_calificacion.png";
            star2.Source = "icon_star_calificacion.png";
            star3.Source = "icon_star_calificacion.png";
            star4.Source = "icon_star_calificacion.png";
            star5.Source = "icon_star_calificacion.png";
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            Telefono = txtTelefono.Text;
            try
            {
                if (Telefono != null)
                {
                    Calificacion_servicio calificacion_ = new Calificacion_servicio()
                    {
                        valor = Calificacion.ToString(),
                        telefono = Convert.ToInt32(txtTelefono.Text),
                        id_servicio = Id_Servicio
                    };

                    var json = JsonConvert.SerializeObject(calificacion_);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpClient client = new HttpClient();

                    var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/calificaciones/agregarCalificacionServicio.php", content);

                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        await DisplayAlert("CALIFICADO", "Gracias por su opinion", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("ERROR", result.StatusCode.ToString(), "OK");
                        await Navigation.PopAsync();
                    }
                }
                else
                {
                    await DisplayAlert("CAMPO OBLIGATORIO", "ES NECESARIO RELLENAR EL CAMPO DE TELEFONO", "OK");
                    txtTelefono.PlaceholderColor = Color.Red;
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("ERROR", err.ToString(), "OK");
            }
        }
    }
}
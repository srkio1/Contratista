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
	public partial class AgregarCalificacion : ContentPage
	{
        private decimal Calificacion;
        private decimal ValidarCalificacion;
        private int Id_Contratista;
        private string Telefono;
		public AgregarCalificacion (string NombreC, int IDContratista)
		{
			InitializeComponent ();
            Id_Contratista = IDContratista;
            txtNombre.Text = NombreC;
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
            ValidarCalificacion = Calificacion;

            try
            {
                if (ValidarCalificacion != 0)
                {

                    if (Telefono.ToString().Length > 7 || 9 < Telefono.ToString().Length)
                    {
                        Calificacion_contratista calificacion_ = new Calificacion_contratista()
                        {
                            valor = Calificacion.ToString(),
                            id_contratista = Id_Contratista,
                            comentarios = txtComentarios.Text,
                            telefono = Convert.ToInt32(txtTelefono.Text)
                        };

                        var json = JsonConvert.SerializeObject(calificacion_);

                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpClient client = new HttpClient();

                        var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/calificaciones/agregarCalificacionContratista.php", content);

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

                else
                {
                    await DisplayAlert("CAMPO OBLIGATORIO", "ES NECESARIO CALIFICAR AL MENOS CON  1 ESTRELLA", "OK");
                    
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
    }
}
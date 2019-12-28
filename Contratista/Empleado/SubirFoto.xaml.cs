using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Net.Http;
using Newtonsoft.Json;
using Contratista.Datos;

namespace Contratista.Empleado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubirFoto : ContentPage
    {
        private MediaFile _mediaFile;
        int imgPicked;
        private int Idportafolio;
        private string Nombre;
        private string Imagen1;
        private string Imagen2;
        private string Imagen3;
        private string Imagen4;
        private string Imagen5;
        private string Imagen6;
        private string Imagen7;
        private int Idprofesional;
        public SubirFoto(int imgPick, int IdPortafolio, string NombreP, string Imagen_1P, string Imagen_2P, string Imagen_3P, string Imagen_4P,
                          string Imagen_5P, string Imagen_6P, string Imagen_7P, int IdProfesional)
        {
            InitializeComponent();
            imgPicked = imgPick;
            Idportafolio = IdPortafolio;
            Nombre = NombreP;
            Imagen1 = Imagen_1P;
            Imagen2 = Imagen_2P;
            Imagen3 = Imagen_3P;
            Imagen4 = Imagen_4P;
            Imagen5 = Imagen_5P;
            Imagen6 = Imagen_6P;
            Imagen7 = Imagen_7P;
            Idprofesional = IdProfesional;
        }

        private async void BtnCamara_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Error", "Camara no disponible", "OK");
                    return;
                }

                _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Small,
                    Name = "test.jpg"
                });

                if (_mediaFile == null)
                    return;

                this.subir_img.Source = ImageSource.FromStream(() =>
                {
                    return _mediaFile.GetStream();
                });

            }
            catch (Exception err)
            {
                await DisplayAlert("Error", err.ToString(), "OK");
            }
        }

        private async void BtnGaleria_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Error", "No se puede acceder a las imagenes", "OK");
                    return;
                }
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null)
                    return;

                subir_img.Source = ImageSource.FromStream(() => _mediaFile.GetStream());

                if (imgPicked == 3)
                {
                    //Imagen3 = "/api_contratistas/images/" +_mediaFile.;
                }
                else if (imgPicked == 4)
                {

                }
                else if (imgPicked == 5)
                {

                }
                else if (imgPicked == 6)
                {

                }
                else if (imgPicked == 7)
                {

                }
                else
                {
                    DisplayAlert("ERROR", "imgPick no asignado", "OK");
                }

            }
            catch (Exception err)
            {
                await DisplayAlert("Error", err.ToString(), "OK");
            }


        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Portafolio_profesional portafolio_Profesional = new Portafolio_profesional()
                {
                    id_portafolio_p = Idportafolio,
                    nombre = Nombre,
                    imagen_1 = Imagen1,
                    imagen_2 = Imagen2,
                    imagen_3 = Imagen3,
                    imagen_4 = Imagen4,
                    imagen_5 = Imagen5,
                    imagen_6 = Imagen6,
                    imagen_7 = Imagen7,
                    id_profesional = Idprofesional
                };
                var json = JsonConvert.SerializeObject(portafolio_Profesional);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/portafolios/editarPortafolio_profesional.php", content);

                try
                {
                    var contentM = new MultipartFormDataContent();
                    contentM.Add(new StreamContent(_mediaFile.GetStream()),
                        "\"file\"",
                        $"\"{_mediaFile.Path}\"");
                    var resultM = await client.PostAsync("http://dmrbolivia.online/api_contratistas/subirImagen.php", contentM);
                }
                catch (Exception err)
                {
                    await DisplayAlert("ERROR", err.ToString(), "OK");
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("Error", err.ToString(), "OK");
            }
        }
    }
}
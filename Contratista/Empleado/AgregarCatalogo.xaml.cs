using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Contratista.Datos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista.Empleado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarCatalogo : ContentPage
    {
        private MediaFile _mediaFile;
        private string ruta;
        private MediaFile _mediaFile2;
        private string ruta2;
        private int IdServicio;
        private string Nombre_Servicio;
        private string Fecha;
        public AgregarCatalogo(int idServicio, string nombre_servicio)
        {
            InitializeComponent();
            IdServicio = idServicio;
            Nombre_Servicio = nombre_servicio;
            Fecha = DateTime.Today.ToString("dd-MM-yyyy hh:mm:ss");
        }

        private async void AgregarImg1_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Agregar imagenes", "Cancel", null, "SACAR FOTO", "ELEGIR DE LA GALERIA");
            switch (action)
            {
                case "SACAR FOTO":
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
                            SaveToAlbum = true,
                            Name = Fecha + Nombre_Servicio + IdServicio + "_1.jpg"
                        });

                        if (_mediaFile == null)
                            return;

                        imagen1Entry.Source = ImageSource.FromStream(() =>
                        {
                            return _mediaFile.GetStream();
                        });
                        ruta = "/api_contratistas/images/" + Fecha + Nombre_Servicio + IdServicio + "_1.jpg";
                        nombreimg1.Text = Fecha + Nombre_Servicio + IdServicio + "_1.jpg";
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
                case "ELEGIR DE LA GALERIA":
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

                        imagen1Entry.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                        string value = _mediaFile.Path.ToString();
                        char[] delimeters = new char[] { '/' };
                        String[] parts = value.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < parts.Length; i++)
                        {
                            nombreimg1.Text = parts[parts.Length - 1].ToString();
                        }

                        ruta = "/api_contratistas/images/" + nombreimg1.Text;
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
            }
        }

        private async void AgregarImg2_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Agregar imagenes", "Cancel", null, "SACAR FOTO", "ELEGIR DE LA GALERIA");
            switch (action)
            {
                case "SACAR FOTO":
                    try
                    {
                        await CrossMedia.Current.Initialize();
                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            await DisplayAlert("Error", "Camara no disponible", "OK");
                            return;
                        }

                        _mediaFile2 = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                        {
                            SaveToAlbum = true,
                            Name = Fecha + Nombre_Servicio + IdServicio + "_2.jpg"
                        });

                        if (_mediaFile2 == null)
                            return;

                        imagen2Entry.Source = ImageSource.FromStream(() =>
                        {
                            return _mediaFile2.GetStream();
                        });
                        ruta2 = "/api_contratistas/images/" + Fecha + Nombre_Servicio + IdServicio + "_2.jpg";
                        nombreImg2.Text = Fecha + Nombre_Servicio + IdServicio + "_2.jpg";
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
                case "ELEGIR DE LA GALERIA":
                    try
                    {
                        if (!CrossMedia.Current.IsPickPhotoSupported)
                        {
                            await DisplayAlert("Error", "No se puede acceder a las imagenes", "OK");
                            return;
                        }
                        _mediaFile2 = await CrossMedia.Current.PickPhotoAsync();
                        if (_mediaFile2 == null)
                            return;

                        imagen2Entry.Source = ImageSource.FromStream(() => _mediaFile2.GetStream());
                        string value = _mediaFile2.Path.ToString();
                        char[] delimeters = new char[] { '/' };
                        String[] parts = value.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < parts.Length; i++)
                        {
                            nombreImg2.Text = parts[parts.Length - 1].ToString();
                        }

                        ruta2 = "/api_contratistas/images/" + nombreImg2.Text;
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(_mediaFile.GetStream()),
                    "\"file\"",
                    $"\"{_mediaFile.Path}\"");
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/subirImagen.php", content);

                var content2 = new MultipartFormDataContent();
                content2.Add(new StreamContent(_mediaFile2.GetStream()),
                    "\"file\"",
                    $"\"{_mediaFile2.Path}\"");
                var result2 = await client.PostAsync("http://dmrbolivia.online/api_contratistas/subirImagen.php", content2);
                Catalogo catalogo = new Catalogo()
                {
                    nombre = nombreEntry.Text,
                    imagen_1 = ruta,
                    imagen_2 = ruta2,
                    descripcion = descripcionEntry.Text,
                    id_servicio = IdServicio
                };

                var json = JsonConvert.SerializeObject(catalogo);
                var content1 = new StringContent(json, Encoding.UTF8, "application/json");
                var result1 = await client.PostAsync("http://dmrbolivia.online/api_contratistas/catalogos/agregarCatalogo.php", content1);

                if (result1.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("Guardar", "Se agrego correctamente", "Ok");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", result.StatusCode.ToString(), "No se pudo Guardar", "Ok");
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
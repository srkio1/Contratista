﻿using Newtonsoft.Json;
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
    public partial class AgregarPromoServicio : ContentPage
    {
        private MediaFile _mediaFile;
        private string ruta;
        private int IdServicio;
        private string Nombre_Servicio;
        static Random _random = new Random();
        private int NumRand;
        public AgregarPromoServicio(int id_servicio, string nombre_servicio)
        {
            InitializeComponent();
            NumRand = _random.Next();
            IdServicio = id_servicio;
            Nombre_Servicio = nombre_servicio;
        }

        private void Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectIndex = picker.SelectedIndex;
            if (selectIndex != -1)
            {
                estadopick = picker.Items[selectIndex];
            }
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
                            PhotoSize = PhotoSize.Small,
                            Name = NumRand + Nombre_Servicio + IdServicio + "_1.jpg"
                        });

                        if (_mediaFile == null)
                            return;

                        imagen1Entry.Source = ImageSource.FromStream(() =>
                        {
                            return _mediaFile.GetStream();
                        });
                        ruta = "/api_contratistas/images/" + NumRand + Nombre_Servicio + IdServicio + "_1.jpg";
                        nombreimg1.Text = NumRand + Nombre_Servicio + IdServicio + "_1.jpg";
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
                        _mediaFile = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                        {
                            SaveMetaData = true,
                            PhotoSize = PhotoSize.Small
                        });
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
        private string estadopick;
        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            cargando.IsVisible = true;
            if (IdServicio != 0)
            {
                if (nombreEntry.Text != null)
                {
                    if (estadopick != null)
                    {
                        if (_mediaFile != null)
                        {
                            try
                            {
                                HttpClient client = new HttpClient();
                                var content = new MultipartFormDataContent();
                                content.Add(new StreamContent(_mediaFile.GetStream()),
                                    "\"file\"",
                                    $"\"{_mediaFile.Path}\"");
                                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/subirImagen.php", content);

                                Promocion_servicios promocion_Servicios = new Promocion_servicios()
                                {
                                    nombre = nombreEntry.Text,
                                    imagen = ruta,
                                    estado = estadopick,
                                    descripcion = descripcionEntry.Text,

                                    id_servicio = IdServicio
                                };
                                var json = JsonConvert.SerializeObject(promocion_Servicios);
                                var content1 = new StringContent(json, Encoding.UTF8, "application/json");
                                var result1 = await client.PostAsync("http://dmrbolivia.online/api_contratistas/promociones/agregarPromoServicio.php", content1);

                                if (result1.StatusCode == HttpStatusCode.OK)
                                {
                                    await DisplayAlert("GUARDAR", "Se agrego la promocion correctamente", "OK");
                                    cargando.IsVisible = false;
                                    await Navigation.PopAsync();
                                }
                                else
                                {
                                    await DisplayAlert("ERROR", result.StatusCode.ToString(), "OK");
                                    cargando.IsVisible = false;
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
                                cargando.IsVisible = false;
                            }
                        }
                        else
                        {
                            await DisplayAlert("ERROR", "Se necesita una imagen para poder guardar", "OK");
                            cargando.IsVisible = false;
                        }
                    }
                    else
                    {
                        await DisplayAlert("ERROR", "El campo de Estado es necesario", "OK");
                        cargando.IsVisible = false;
                    }
                }
                else
                {
                    await DisplayAlert("ERROR", "El campo de Nombre es necesario", "OK");
                    cargando.IsVisible = false;
                }
            }
            else
            {
                await DisplayAlert("ERROR", "Algo salio mal, intentelo de nuevo", "OK");
                cargando.IsVisible = false;
                await Navigation.PopAsync();
            }
        }
    }
}
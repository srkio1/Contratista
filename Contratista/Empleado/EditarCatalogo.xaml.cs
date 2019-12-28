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
    public partial class EditarCatalogo : ContentPage
    {
        private int IDCatalogo;
        private string IMG1;
        private string IMG2;
        private int IDServicio;
        public EditarCatalogo(int IdCatalogo, string Nombre, string Imagen1, string Imagen2, string Descripcion, int IdServicio)
        {
            InitializeComponent();
            IDCatalogo = IdCatalogo;
            IMG1 = Imagen1;
            IMG2 = Imagen2;
            IDServicio = IdServicio;
            txtNombre.Text = Nombre;
            txtDescripcion.Text = Descripcion;
        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            if (IDCatalogo != 0)
            {
                if (IDServicio != 0)
                {
                    if (txtNombre.Text.Length > 0)
                    {
                        if (txtDescripcion.Text.Length > 0)
                        {
                            try
                            {
                                Catalogo catalogo = new Catalogo()
                                {
                                    id_catalogo = IDCatalogo,
                                    nombre = txtNombre.Text,
                                    imagen_1 = IMG1,
                                    imagen_2 = IMG2,
                                    descripcion = txtDescripcion.Text,
                                    id_servicio = IDServicio
                                };

                                var json = JsonConvert.SerializeObject(catalogo);
                                var content = new StringContent(json, Encoding.UTF8, "application/json");
                                HttpClient client = new HttpClient();
                                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/catalogos/editarCatalogo.php", content);

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
                        else
                        {
                            await DisplayAlert("ERROR", "El campo de descripcion es necesario", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("ERROR", "El campo de Nombre es necesario", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("ERROR", "Algo salio mal, intentelo de nuevo", "OK");
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("ERROR", "Algo salio mal, intentelo de nuevo", "OK");
                await Navigation.PopAsync();
            }
        }

        private async void BtnBorrar_Clicked(object sender, EventArgs e)
        {
            if (IDCatalogo != 0)
            {
                try
                {
                    Catalogo catalogo = new Catalogo()
                    {
                        id_catalogo = IDCatalogo,
                        nombre = txtNombre.Text,
                        imagen_1 = IMG1,
                        imagen_2 = IMG2,
                        descripcion = txtDescripcion.Text,
                        id_servicio = IDServicio
                    };

                    var json = JsonConvert.SerializeObject(catalogo);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpClient client = new HttpClient();
                    var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/catalogos/borrarCatalogo.php", content);

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
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("ERROR", "Algo salio mal, intentelo de nuevo", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
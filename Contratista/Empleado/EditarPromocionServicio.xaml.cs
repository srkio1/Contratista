using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Contratista.Datos;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista.Empleado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPromocionServicio : ContentPage
    {
        private int IDPromo;
        private int IDServicio;
        private string ImagenS;
        public EditarPromocionServicio(int id, string nombre, string estado, string descripcion, string imagen, int id_promocion_s)
        {
            InitializeComponent();
            txtNombre.Text = nombre;
            txtDescripcion.Text = descripcion;
            IDPromo = id_promocion_s;
            IDServicio = id;
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
            if (IDPromo > 0)
            {
                if (IDServicio > 0)
                {
                    if (txtNombre.Text.Length > 0)
                    {
                        if (estadopick.Length > 0)
                        {
                            if (txtDescripcion.Text.Length > 0)
                            {
                                try
                                {
                                    Promocion_servicios promocion_Servicios = new Promocion_servicios()
                                    {
                                        id_promocion_s = IDPromo,
                                        nombre = txtNombre.Text,
                                        estado = estadopick,
                                        imagen = ImagenS,
                                        descripcion = txtDescripcion.Text,
                                        id_servicio = IDServicio
                                    };

                                    var json = JsonConvert.SerializeObject(promocion_Servicios);
                                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                                    HttpClient client = new HttpClient();
                                    var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/promociones/editarPromoServicio.php", content);

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
                                await DisplayAlert("ERROR", "El campo de Descripcion es necesario", "OK");
                            }
                        }
                        else
                        {
                            await DisplayAlert("ERROR", "El campo de Estado es necesario", "OK");
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
            if (IDPromo > 0)
            {
                try
                {
                    Promocion_servicios promocion_Servicios = new Promocion_servicios()
                    {
                        id_promocion_s = IDPromo,
                        nombre = txtNombre.Text,
                        estado = estadopick,
                        descripcion = txtDescripcion.Text,
                        id_servicio = IDServicio
                    };

                    var json = JsonConvert.SerializeObject(promocion_Servicios);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpClient client = new HttpClient();
                    var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/promociones/borrarPromoServicio.php", content);

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
                await DisplayAlert("ERROR", "Algo salio mal, intentelo de nuevo", "OK");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contratista.Datos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace Contratista.Empleado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarFormacionAcademica : ContentPage
    {
        private int IDProfesional;
        public AgregarFormacionAcademica(int IdProfesional)
        {
            InitializeComponent();
            IDProfesional = IdProfesional;
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            if (IDProfesional != 0)
            {
                if (txtTitulo.Text.Length > 0)
                {
                    if (txtLugar.Text.Length > 0)
                    {
                        try
                        {
                            Formacion_academica formacion = new Formacion_academica()
                            {
                                titulo = txtTitulo.Text,
                                lugar = txtLugar.Text,
                                id_profesional = IDProfesional
                            };

                            var json = JsonConvert.SerializeObject(formacion);

                            var content = new StringContent(json, Encoding.UTF8, "application/json");

                            HttpClient client = new HttpClient();

                            var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/curriculum/agregarFormacionAcademica.php", content);

                            if (result.StatusCode == HttpStatusCode.OK)
                            {
                                await DisplayAlert("GUARDARDO", "Se agrego correctamente", "OK");
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
                        await DisplayAlert("ERROR", "El campo de Lugar es obligatorio", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("ERROR", "El campo de Titulo es obligatorio", "OK");
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
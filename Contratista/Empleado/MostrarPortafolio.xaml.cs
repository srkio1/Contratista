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
    public partial class MostrarPortafolio : ContentPage
    {
        int IdPortafolio;
        private string NombrePortafolio;
        private string IMG1;
        private string IMG2;
        private string IMG3;
        private string IMG4;
        private string IMG5;
        private string IMG6;
        private string IMG7;
        public MostrarPortafolio(int id_portafolio, string nombre, string imagen_1, string imagen_2, string imagen_3, string imagen_4, string imagen_5, string imagen_6,
                                 string imagen_7, int id_profesional)
        {
            InitializeComponent();
            IdPortafolio = id_portafolio;
            IMG1 = imagen_1;
            IMG2 = imagen_2;
            IMG3 = imagen_3;
            IMG4 = imagen_4;
            IMG5 = imagen_5;
            IMG6 = imagen_6;
            IMG7 = imagen_7;
            NombrePortafolio = nombre;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<CustomData> GetDataSource()
            {

                List<CustomData> list = new List<CustomData>();
                list.Add(new CustomData("http://dmrbolivia.online" + IMG1));
                list.Add(new CustomData("http://dmrbolivia.online" + IMG2));
                if (IMG3.Length > 0)
                {
                    list.Add(new CustomData("http://dmrbolivia.online" + IMG3));
                }
                if (IMG4.Length > 0)
                {
                    list.Add(new CustomData("http://dmrbolivia.online" + IMG4));
                }
                if (IMG5.Length > 0)
                {
                    list.Add(new CustomData("http://dmrbolivia.online" + IMG5));
                }
                if (IMG6.Length > 0)
                {
                    list.Add(new CustomData("http://dmrbolivia.online" + IMG6));
                }
                if (IMG7.Length > 0)
                {
                    list.Add(new CustomData("http://dmrbolivia.online" + IMG7));
                }
                return list;
            }
            rotator.ItemsSource = GetDataSource();
            TituloTxt.Text = NombrePortafolio;
        }

        private async void BtnBorrar_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("BORRAR PORTAFOLIO?", null, null, "SI", "NO");
            switch (action)
            {
                case "SI":
                    try
                    {
                        Portafolio_profesional portafolio_Profesional = new Portafolio_profesional()
                        {
                            id_portafolio_p = IdPortafolio
                        };

                        var json = JsonConvert.SerializeObject(portafolio_Profesional);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        HttpClient client = new HttpClient();
                        var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/portafolios/borrarPortafolioProfesional.php", content);

                        if (result.StatusCode == HttpStatusCode.OK)
                        {
                            await DisplayAlert("BORRAR", "Se borro correctamente", "OK");
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
                        await DisplayAlert("Error", "Algo salio mal, Intentalo de nuevo", "OK");
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
                    break;
                case "NO":
                    break;
            }
        }
    }
}
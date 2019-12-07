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
	public partial class VerportafolioEmpresaE : ContentPage
	{
        string Nombre;
        private int IDPortafolio;
        public VerportafolioEmpresaE(int id_portafolio_e, string nombre, string imagen_1, string imagen_2, string imagen_3, string imagen_4, string imagen_5, string imagen_6,
                                 string imagen_7, int id_empresa)
        {

            InitializeComponent();
            IDPortafolio = id_portafolio_e;

            List<CustomData> GetDataSource()
            {
                List<CustomData> list = new List<CustomData>();
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_1));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_2));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_3));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_4));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_5));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_6));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_7));
                return list;
            }
            rotator.ItemsSource = GetDataSource();
            TituloTxt.Text = nombre;
        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("BORRAR PORTAFOLIO?", null, null, "SI", "NO");
            switch (action)
            {
                case "SI":
                    try
                    {
                        Portafolio_empresa portafolio_Empresa = new Portafolio_empresa()
                        {
                            id_portafolio_e = IDPortafolio
                        };

                        var json = JsonConvert.SerializeObject(portafolio_Empresa);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        HttpClient client = new HttpClient();
                        var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/portafolios/borrarPortafolioEmpresa.php", content);

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
                        await DisplayAlert("ERROR", err.ToString(), "OK");
                    }
                    break;
                case "NO":
                    break;
            }
        }
    }
}
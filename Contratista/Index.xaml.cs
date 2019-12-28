using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using TabbedPage = Xamarin.Forms.TabbedPage;
using System.Net.Http;
using Newtonsoft.Json;
using Contratista.Datos;
using Contratista.Empleado;
using System.Net;
using Xamarin.Essentials;

namespace Contratista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Index : TabbedPage
    {
        private string TextoBuscador;
        private int Numero_telefono;
        public Index()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            GetScroll();
        }

        private void GetScroll()
        {
            List<CustomData> GetDataSource()
            {
                List<CustomData> list = new List<CustomData>();
                list.Add(new CustomData("http://dmrbolivia.online/api_contratistas/images/cemento1.jpg"));
                list.Add(new CustomData("http://dmrbolivia.online/api_contratistas/images/clavos1.jpg"));
                list.Add(new CustomData("http://dmrbolivia.online/api_contratistas/images/ladrillo1.jpg"));
                list.Add(new CustomData("http://dmrbolivia.online/api_contratistas/images/708060366Alquimaqui7_1.jpg"));
                list.Add(new CustomData("http://dmrbolivia.online/api_contratistas/images/promo_20.jpg"));

                return list;
            }
            carousel1.ItemsSource = GetDataSource();
        }
        private void BtnIalbanil_Clicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new MenuContratistas());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           Navigation.PushAsync(new MenuContratistas());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
          Navigation.PushAsync(new MenuProfesionales());
        }
        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
           Navigation.PushAsync(new MenuServicios());
        }
        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MenuMateriales());
        }
        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MenuEmpresas());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new MenuEmpresas());
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Feed_Back.Info());
        }

        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            cargando.IsVisible = true;
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/queryLogin.php");
                var data = JsonConvert.DeserializeObject<List<Login>>(response);

                foreach (var item in data)
                {
                    var responseC = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/contratistas/listaContratista.php");
                    var dataC = JsonConvert.DeserializeObject<List<Datos.Contratista>>(responseC);
                    if (usuarioEntry.Text == item.usuario)
                    {
                        if (contrasenaEntry.Text == item.contrasena)
                        {
                            foreach (var item2 in dataC)
                            {
                                if (usuarioEntry.Text == item2.usuario)
                                {
                                    await Navigation.PushAsync(new IndexEmpleado(item2.id_contratista, item2.nombre, item2.apellido_paterno, item2.apellido_materno,
                                                                                 item2.telefono, item2.direccion , item2.foto , item2.cedula_identidad, item2.rubro,
                                                                                 item2.calificacion, item2.estado, item2.prioridad, item2.descripcion, item2.nit , item2.usuario,
                                                                                 item2.contrasena));
                                    cargando.IsVisible = false;
                                }
                                else
                                {
                                    cargando.IsVisible = false; ;
                                }
                            }

                            var responseP = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/profesionales/listaProfesional.php");
                            var dataP = JsonConvert.DeserializeObject<List<Profesional>>(responseP);
                            foreach (var item3 in dataP)
                            {
                                if (usuarioEntry.Text == item3.usuario)
                                {
                                    await Navigation.PushAsync(new IndexProfesional(item3.id_profesional, item3.nombre, item3.apellido_paterno, item3.apellido_materno,
                                                                                    item3.telefono, item3.email, item3.direccion, item3.foto,item3.cedula_identidad, item3.rubro,
                                                                                    item3.calificacion, item3.estado, item3.prioridad, item3.descripcion, item3.nit,
                                                                                       item3.curriculum ,item3.usuario , item3.contrasena));
                                    cargando.IsVisible = false;

                                }
                                else
                                {
                                   cargando.IsVisible=false ;
                                }
                            }

                            var responseS = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/servicios/listaServicio.php");
                            var dataS = JsonConvert.DeserializeObject<List<Servicio>>(responseS);
                            foreach (var item4 in dataS)
                            {

                                if (usuarioEntry.Text == item4.usuario)
                                {
                                    await Navigation.PushAsync(new IndexServicio(item4.id_servicio, item4.nombre, item4.telefono, item4.email, item4.direccion ,
                                        item4.ubicacion_lat, item4.ubicacion_long, item4.foto, item4.estado, item4.nit, item4.rubro, item4.calificacion, item4.prioridad,  item4.descripcion,
                                                                                   item4.usuario , item4.contrasena));
                                    cargando.IsVisible = false;
                                }
                                else
                                {
                                    cargando.IsVisible = false; ;
                                }
                            }

                            var responseM = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/materiales/listaMaterial.php");
                            var dataM = JsonConvert.DeserializeObject<List<Material>>(responseM);
                            foreach (var item5 in dataM)
                            {
                                if (usuarioEntry.Text == item5.usuario)
                                {
                                    await Navigation.PushAsync(new IndexMaterial(item5.id_material, item5.nombre, item5.telefono, item5.email, item5.direccion,
                                        item5.ubicacion_lat, item5.ubicacion_long, item5.foto, item5.nit, item5.rubro, item5.calificacion,
                                                                                   item5.prioridad,   item5.descripcion, item5.usuario , item5.contrasena
                                                                                  ));
                                    cargando.IsVisible = false;
                                }
                                else
                                {
                                    cargando.IsVisible = false; ;
                                }
                            }

                            var responseE = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/empresas/listaEmpresa.php");
                            var dataE = JsonConvert.DeserializeObject<List<Empresa>>(responseE);
                            foreach (var item6 in dataE)
                            {
                                if (usuarioEntry.Text == item6.usuario)
                                {
                                    await Navigation.PushAsync(new IndexEmpresa(item6.id_empresa, item6.nombre, item6.telefono, item6.email, item6.direccion,
                                        item6.ubicacion_lat, item6.ubicacion_long, item6.foto, item6.nit,
                                        item6.rubro, item6.calificacion, item6.prioridad,   item6.descripcion, item6.fundaempresa, item6.usuario, item6.contrasena ));
                                    cargando.IsVisible = false;
                                }
                                else
                                {
                                    cargando.IsVisible = false; ;
                                }
                            }
                        }
                        else
                        {
                            await DisplayAlert("", "Contrasena incorrecta", "OK");
                            cargando.IsVisible = false;
                        }
                    }
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

        private void Buscador_SearchButtonPressed(object sender, EventArgs e)
        {
            TextoBuscador = buscador.Text;
            Navigation.PushAsync(new Busqueda(TextoBuscador));
        }

        private async void BtnContactarSoporte_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Perdio su contraseña?", null, "SALIR", "Solicitar nueva contraseña", "Llamar", "Mensaje");
            switch (action)
            {
                case "Solicitar nueva contraseña":
                    try
                    {
                        string txtcomentario = await DisplayPromptAsync("Ingrese el usuario", "Si no recuerda su usuario anote su nombre completo porfavor");

                        Solicitud_contrasena solicitud_ = new Solicitud_contrasena()
                        {
                            usuario = usuarioEntry.Text,
                            comentario = txtcomentario,
                            fecha = DateTime.Now.ToLocalTime()
                        };

                        var json = JsonConvert.SerializeObject(solicitud_);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        HttpClient client = new HttpClient();
                        var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarSolicitud_contrasena.php", content);

                        if (result.StatusCode == HttpStatusCode.OK)
                        {
                            await DisplayAlert("ENVIADO", "Se envio la solicitud de nueva contraseña correctamente, en breve estaremos en contacto con usted", "OK");
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
                case "Llamar":
                    
                    try
                    {
                        PhoneDialer.Open(Numero_telefono.ToString());
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
                    break;
                case "Mensaje":
                    try
                    {
                        Datos.Chat.Open("+591" + Numero_telefono, " ");
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.Message, "OK");
                    }
                    break;
            }
        }

        private void BtnPublicidad_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Publicidad());
        }
    }
}
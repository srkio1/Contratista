using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Contratista.Datos;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Contratista.Feed_Back;

namespace Contratista.Empleado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndexProfesional : TabbedPage
    {
        private int IdProfesional;
        private string Nombre_Profesional;
        private string Apellido_paterno;
        private string Apellido_materno;
        private int Telefono;
        private string Email;
        private string Direccion;
        private string Foto;
        private string Cedula_identidad;
        private string Rubro;
        private decimal Calificacion;
        private string Estado;
        private int Prioridad;
        private string Descripcion;
        private int Nit;
        private string Curriculum;
        private string Usuario;
        private string Contrasena;
        ObservableCollection<Portafolio_profesional> portafolio_Profesionals = new ObservableCollection<Portafolio_profesional>();
        public ObservableCollection<Portafolio_profesional> Portafolios { get { return portafolio_Profesionals; } }
        public IndexProfesional(int id_profesional, string nombre, string apellido_paterno, string apellido_materno, int telefono, string email,
                              string direccion, string foto, string cedula_identidad, string rubro, decimal calificacion, string estado,
                                 int prioridad, string descripcion, int nit, string curriculum, string usuario, string contrasena)
        {
            InitializeComponent();
            IdProfesional = id_profesional;
            Nombre_Profesional = nombre;
            Apellido_paterno = apellido_paterno;
            Apellido_materno = apellido_materno;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            Foto = foto;
            Cedula_identidad = cedula_identidad;
            Rubro = rubro;
            Calificacion = calificacion;
            Estado = estado;
            Prioridad = prioridad;
            Descripcion = descripcion;
            Nit = nit;
            Curriculum = curriculum;
            Usuario = usuario;
            Contrasena = contrasena;
            IdProfesional = id_profesional;
            Nombre_Profesional = nombre;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetDatos();
            portafolio_Profesionals.Clear();
            GetInfo();
        }
        private async void GetDatos()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/profesionales/listaProfesional.php");
                var profesionales = JsonConvert.DeserializeObject<List<Profesional>>(response);

                foreach (var item in profesionales.Distinct())
                {
                    if (item.id_profesional == IdProfesional)
                    {
                        txtNombre.Text = item.nombre + " " + item.apellido_paterno + " " + item.apellido_materno;
                        txtTelefono.Text = item.telefono.ToString();
                        txtEmail.Text = item.email;
                        txtRubro.Text = item.rubro;
                        txtEstado.Text = item.estado;
                        txtPrioridad.Text = item.prioridad.ToString();
                        txtNit.Text = item.nit.ToString();
                        txtDescripcion.Text = item.descripcion;
                        txtCurriculum.Text = item.curriculum;
                        img_perfil.Source = "http://dmrbolivia.online" + item.foto;
                    }
                }
            }

            catch (Exception erro)
            {
                await DisplayAlert("Error", "Algo salio mal, intentalo de nuevo", "OK");
                ReportesLogs reportesLogs = new ReportesLogs()
                {
                    descripcion = erro.ToString(),
                    fecha = DateTime.Now.ToLocalTime()
                };
                var json = JsonConvert.SerializeObject(reportesLogs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarReporteLog.php", content);
            }
        }
        private async void GetInfo()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/portafolios/listaPortafolio_profesional.php");
                var portafolios = JsonConvert.DeserializeObject<List<Portafolio_profesional>>(response);

                foreach (var item in portafolios.Distinct())
                {
                    if (item.id_profesional == IdProfesional)
                    {
                        portafolio_Profesionals.Add(new Portafolio_profesional
                        {
                            nombre = item.nombre,
                            id_portafolio_p = item.id_portafolio_p,
                            imagen_1 = item.imagen_1,
                            imagen_2 = item.imagen_2,
                            imagen_3 = item.imagen_3,
                            imagen_4 = item.imagen_4,
                            imagen_5 = item.imagen_5,
                            imagen_6 = item.imagen_6,
                            imagen_7 = item.imagen_7,
                            id_profesional = item.id_profesional

                        });
                    }
                }
            }

            catch (Exception erro)
            {
                await DisplayAlert("Error", "Algo salio mal, intentalo de nuevo", "OK");
                ReportesLogs reportesLogs = new ReportesLogs()
                {
                    descripcion = erro.ToString(),
                    fecha = DateTime.Now.ToLocalTime()
                };
                var json = JsonConvert.SerializeObject(reportesLogs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarReporteLog.php", content);
            }
            listPortafolios.ItemsSource = portafolio_Profesionals.Distinct();
        }
        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Portafolio_profesional;
            await Navigation.PushAsync(new MostrarPortafolio(detalles.id_portafolio_p, detalles.nombre, detalles.imagen_1, detalles.imagen_2, detalles.imagen_3,
                                                            detalles.imagen_4, detalles.imagen_5, detalles.imagen_6, detalles.imagen_7, detalles.id_profesional));
        }

        protected void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarPortafolio(IdProfesional, Nombre_Profesional));
        }

        private void Modificar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModificarProfesional(IdProfesional, Nombre_Profesional, Apellido_paterno, Apellido_materno, Telefono, Email, Direccion, Foto,
                        Cedula_identidad, Rubro, Calificacion, Estado, Prioridad, Descripcion, Nit, Curriculum, Usuario, Contrasena));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarCurriculum(IdProfesional, Nombre_Profesional, Email, Telefono));
        }
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Alert", "Quiere Cerrar Sesion", "Si", "No");
                if (result) await this.Navigation.PushAsync(new Index());
            });
            return true;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarFeedBackProfesional(IdProfesional));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contratista.Empleado;
using Contratista.Datos;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Contratista.Empleado
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IndexEmpresa : TabbedPage
	{
        private int idEmpresa;
        private string nombre_empresa;
        ObservableCollection<Portafolio_empresa> portafolio_Empresas = new ObservableCollection<Portafolio_empresa>();
        public ObservableCollection<Portafolio_empresa> Portafolios { get { return portafolio_Empresas; } }
        public IndexEmpresa(int id_empresa, string nombre, int telefono, string email, string rubro, int prioridad, decimal calificacion, string foto, string descripcion,
                             int nit)
        {
            InitializeComponent();
            idEmpresa = id_empresa;
            idEntry.Text = id_empresa.ToString();
            txtNombre.Text = nombre;
            txtTelefono.Text = telefono.ToString();
            txtEmail.Text = email;
            txtRubro.Text = rubro;
            txtPrioridad.Text = prioridad.ToString();
            decimal CalificacionEmpresa = calificacion;
            txtNit.Text = nit.ToString();
            txtDescripcion.Text = descripcion;
            img_perfil.Source = "http://dmrbolivia.online" + foto;
            GetInfo();
        }
        private async void GetInfo()
        {

            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/portafolios/listaPortafolio_empresa.php");
                var portafolios = JsonConvert.DeserializeObject<List<Portafolio_empresa>>(response);

                foreach (var item in portafolios.Distinct())
                {
                    if (item.id_empresa == idEmpresa)
                    {
                        portafolio_Empresas.Add(new Portafolio_empresa
                        {
                            nombre = item.nombre,
                            id_portafolio_e = item.id_portafolio_e,
                            imagen_1 = item.imagen_1,
                            imagen_2 = item.imagen_2,
                            imagen_3 = item.imagen_3,
                            imagen_4 = item.imagen_4,
                            imagen_5 = item.imagen_5,
                            imagen_6 = item.imagen_6,
                            imagen_7 = item.imagen_7,
                            id_empresa = item.id_empresa
                        });
                    }
                }




            }

            catch (Exception erro)
            {
                Console.Write("EEERRROOOORRR= " + erro);
            }
            listPortafolios.ItemsSource = portafolio_Empresas.Distinct();
        }

        private async void ListPortafolios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Portafolio_empresa;
            await Navigation.PushAsync(new VerportafolioEmpresaE(detalles.id_portafolio_e, detalles.nombre, detalles.imagen_1, detalles.imagen_2, detalles.imagen_3,
                                                            detalles.imagen_4, detalles.imagen_5, detalles.imagen_6, detalles.imagen_7, detalles.id_empresa));


        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarPortafolioEmpresa(idEmpresa, nombre_empresa));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista.Empleado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VercatalogoServicio : ContentPage
    {
        string Nombre;
        private int IdServicio;
        private int IdCatalogo;
        private string Imagen1;
        private string Imagen2;
        private string Descripcion;
        public VercatalogoServicio(int id_catalogo, string nombre, string imagen_1, string imagen_2, string descripcion, int id_servicio)
        {
            InitializeComponent();
            Nombre = nombre;
            IdServicio = id_servicio;
            IdCatalogo = id_catalogo;
            Imagen1 = imagen_1;
            Imagen2 = imagen_2;
            Descripcion = descripcion;

            List<CustomData> GetDataSource()
            {
                List<CustomData> list = new List<CustomData>();
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_1));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_2));

                return list;
            }
            rotator.ItemsSource = GetDataSource();
            TituloTxt.Text = nombre;
            DescripcionTxt.Text = descripcion;
        }
        private void BtnEditar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditarCatalogo(IdCatalogo, Nombre, Imagen1, Imagen2, Descripcion, IdServicio));
        }
    }
}
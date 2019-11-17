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
        public VercatalogoServicio(int id_catalogo, string nombre, string imagen_1, string imagen_2, string descripcion, int id_servicio)
        {
            InitializeComponent();
            List<CustomData> GetDataSource()
            {
                List<CustomData> list = new List<CustomData>();
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_1));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_2));

                return list;
            }
            rotator.ItemsSource = GetDataSource();
            TituloTxt.Text = nombre;
        }
    }
}
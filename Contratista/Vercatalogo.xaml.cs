using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfRotator.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Vercatalogo : ContentPage
	{
        public Vercatalogo(int id_catalogo, string nombre, string imagen_1, string imagen_2, string descripcion)
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
            DescripcionTxt.Text = descripcion;
        }
    }
}
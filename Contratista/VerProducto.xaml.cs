using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net.Http;
using Contratista.Datos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerProducto : ContentPage
	{
        private int IdProducto;
        private string Nombre;
        private string Descripcion;
        private string Imagen1;
        private string Imagen2;
        private int IdMaterial;
        public VerProducto(int id_producto, string nombre, string descripcion, string imagen_1, string imagen_2, int id_material)
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
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
	public partial class VerProductoMaterial : ContentPage
	{
        private int IdProducto;
        private string Nombre;
        private string Descripcion;
        private string Imagen1;
        private string Imagen2;
        private int IdMaterial;
        public VerProductoMaterial (int id_producto, string nombre, string descripcion, string imagen_1, string imagen_2, int id_material)
		{
			InitializeComponent ();
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
            IdProducto = id_producto;
            Nombre = nombre;
            Descripcion = descripcion;
            Imagen1 = imagen_1;
            Imagen2 = imagen_2;
            IdMaterial = id_material;
        }
        private void BtnEditar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditarProducto(IdProducto, Nombre, Imagen1, Imagen2, Descripcion, IdMaterial));
        }
    }
}
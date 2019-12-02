using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerPortafolioEmpresa : ContentPage
	{
        private int IdPortafolioEmpresa;
        private string Nombre;
        private string Imagen1;
        private string Imagen2;
        private string Imagen3;
        private string Imagen4;
        private string Imagen5;
        private string Imagen6;
        private string Imagen7;
        private int IdEmpresa;
        public VerPortafolioEmpresa(int id_portafolio_e, string nombre, string imagen_1, string imagen_2, string imagen_3, string imagen_4,
            string imagen_5, string imagen_6, string imagen_7, int id_empresa)
        {
            InitializeComponent();

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
    }
}
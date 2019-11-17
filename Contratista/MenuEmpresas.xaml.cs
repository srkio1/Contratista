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
	public partial class MenuEmpresas : ContentPage
	{
        private string rubro;
        public MenuEmpresas()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            rubro = "Constructora";
            Navigation.PushAsync(new ListaEmpresa(rubro));
        }

        private void BtnConstructora_Clicked(object sender, EventArgs e)
        {
            rubro = "Constructora";
            Navigation.PushAsync(new ListaEmpresa(rubro));
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            rubro = "Diseno";
            Navigation.PushAsync(new ListaEmpresa(rubro));
        }

        private void BtnDiseno_Clicked(object sender, EventArgs e)
        {
            rubro = "Diseno";
            Navigation.PushAsync(new ListaEmpresa(rubro));
        }
    }
}
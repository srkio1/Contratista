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
	public partial class MenuMateriales : ContentPage
	{
        private string rubro;
        public MenuMateriales()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            rubro = "Ferreteria";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void BtnFerreteria_Clicked(object sender, EventArgs e)
        {
            rubro = "Ferreteria";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            rubro = "Barraca";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void BtnBarracas_Clicked(object sender, EventArgs e)
        {
            rubro = "Barraca";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            rubro = "Cemento";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void BtnCemento_Clicked(object sender, EventArgs e)
        {
            rubro = "Cemento";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            rubro = "Agregados";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void BtnAridos_Clicked(object sender, EventArgs e)
        {
            rubro = "Agregados";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            rubro = "Vidrieria";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void BtnVidrieria_Clicked(object sender, EventArgs e)
        {
            rubro = "Vidrieria";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            rubro = "Ceramica";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void BtnCeramica_Clicked(object sender, EventArgs e)
        {
            rubro = "Ceramica";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            rubro = "Ladrillo";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void BtnLadrillo_Clicked(object sender, EventArgs e)
        {
            rubro = "Ladrillo";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            rubro = "Acero";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }
        private void BtnAcero_Clicked(object sender, EventArgs e)
        {
            rubro = "Acero";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            rubro = "Pretensados";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void BtnPretensados_Clicked(object sender, EventArgs e)
        {
            rubro = "Pretensados";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void BtnTuberias_Clicked(object sender, EventArgs e)
        {
            rubro = "Tuberia";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }
        private void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            rubro = "Tuberia";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        private void BtnCables_Clicked(object sender, EventArgs e)
        {
            rubro = "Cable";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }
        private void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
        {
            rubro = "Cable";
            Navigation.PushAsync(new ListaMaterial(rubro));
        }

        
    }
}
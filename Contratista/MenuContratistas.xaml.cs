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
    public partial class MenuContratistas : ContentPage
    {
        private string rubro;
        public MenuContratistas()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            rubro = "Albañil";
            Navigation.PushAsync(new ListaContratista(rubro));
        }
        private void BtnAlbanil_Clicked(object sender, EventArgs e)
        {
            rubro = "Albañil";
            Navigation.PushAsync(new ListaContratista(rubro));
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            rubro = "Plomero";
            Navigation.PushAsync(new ListaContratista(rubro));
        }
        private void BtnPlomero_Clicked(object sender, EventArgs e)
        {
            rubro = "Plomero";
            Navigation.PushAsync(new ListaContratista(rubro));
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            rubro = "Soldador";
            Navigation.PushAsync(new ListaContratista(rubro));
        }
        private void BtnSoldador_Clicked(object sender, EventArgs e)
        {
            rubro = "Soldador";
            Navigation.PushAsync(new ListaContratista(rubro));
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            rubro = "Electricista";
            Navigation.PushAsync(new ListaContratista(rubro));
        }
        private void BtnElectricista_Clicked(object sender, EventArgs e)
        {
            rubro = "Electricista";
            Navigation.PushAsync(new ListaContratista(rubro));
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            rubro = "Carpintero";
            Navigation.PushAsync(new ListaContratista(rubro));
        }
        private void BtnCarpintero_Clicked(object sender, EventArgs e)
        {
            rubro = "Carpintero";
            Navigation.PushAsync(new ListaContratista(rubro));
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            rubro = "Pintor";
            Navigation.PushAsync(new ListaContratista(rubro));
        }
        private void BtnPintor_Clicked(object sender, EventArgs e)
        {
            rubro = "Pintor";
            Navigation.PushAsync(new ListaContratista(rubro));
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            rubro = "Aire acondicionado";
            Navigation.PushAsync(new ListaContratista(rubro));
        }
        private void BtnAireAcondicionado_Clicked(object sender, EventArgs e)
        {
            rubro = "Aire acondicionado";
            Navigation.PushAsync(new ListaContratista(rubro));
        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            rubro = "Cerrajero";
            Navigation.PushAsync(new ListaContratista(rubro));
        }
        private void BtnCerrajero_Clicked(object sender, EventArgs e)
        {
            rubro = "Cerrajero";
            Navigation.PushAsync(new ListaContratista(rubro));
        }

        private void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            rubro = "Jardinero";
            Navigation.PushAsync(new ListaContratista(rubro));
        }
        private void BtnJardinero_Clicked(object sender, EventArgs e)
        {
            rubro = "Jardinero";
            Navigation.PushAsync(new ListaContratista(rubro));
        }

        private void BtnVidriero_Clicked(object sender, EventArgs e)
        {
            rubro = "Vidriero";
            Navigation.PushAsync(new ListaContratista(rubro));
        }

        private void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
        {
            rubro = "Vidriero";
            Navigation.PushAsync(new ListaContratista(rubro));
        }

        private void BtnOperador_Clicked(object sender, EventArgs e)
        {
            rubro = "Operador";
            Navigation.PushAsync(new ListaContratista(rubro));
        }

        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            rubro = "Operador";
            Navigation.PushAsync(new ListaContratista(rubro));
        }
    }
}
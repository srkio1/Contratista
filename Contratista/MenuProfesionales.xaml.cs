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
	public partial class MenuProfesionales : ContentPage
	{
        public string rubro;
        public MenuProfesionales()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            rubro = "Ingeniero civil";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }
        private void BtnIngCivil_Clicked(object sender, EventArgs e)
        {
            rubro = "Ingeniero civil";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            rubro = "Arquitecto";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }
        private void BtnArquitecto_Clicked(object sender, EventArgs e)
        {
            rubro = "Arquitecto";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            rubro = "Ingeniero electrico";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }
        private void BtnIngElectrico_Clicked(object sender, EventArgs e)
        {
            rubro = "Ingeniero electrico";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            rubro = "Topografo";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }
        private void BtnTopografo_Clicked(object sender, EventArgs e)
        {
            rubro = "Topografo";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            rubro = "Calculista";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }
        private void BtnCalculista_Clicked(object sender, EventArgs e)
        {
            rubro = "Calculista";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            rubro = "Ingeniero hidraulico";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }
        private void BtnIngHidraulico_Clicked(object sender, EventArgs e)
        {
            rubro = "Ingeniero hidraulico";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            rubro = "Cadista";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }
        private void BtnCadista_Clicked(object sender, EventArgs e)
        {
            rubro = "Cadista";
            Navigation.PushAsync(new ListaProfesional(rubro));
        }
    }
}
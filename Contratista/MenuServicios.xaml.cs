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
	public partial class MenuServicios : ContentPage
	{
        private string rubro;
        public MenuServicios()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            rubro = "Alquiler de maquinaria";
            Navigation.PushAsync(new ListaServicio(rubro));
        }

        private void BtnMaquinaria_Clicked(object sender, EventArgs e)
        {
            rubro = "Alquiler de maquinaria";
            Navigation.PushAsync(new ListaServicio(rubro));
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            rubro = "Alquiler de equipos";
            Navigation.PushAsync(new ListaServicio(rubro));
        }

        private void BtnEquipos_Clicked(object sender, EventArgs e)
        {
            rubro = "Alquiler de equipos";
            Navigation.PushAsync(new ListaServicio(rubro));
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            rubro = "Alquiler de herramientas";
            Navigation.PushAsync(new ListaServicio(rubro));
        }

        private void BtnHerramienta_Clicked(object sender, EventArgs e)
        {
            rubro = "Alquiler de herramientas";
            Navigation.PushAsync(new ListaServicio(rubro));
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            rubro = "Transporte";
            Navigation.PushAsync(new ListaServicio(rubro));
        }

        private void BtnTrasnporte_Clicked(object sender, EventArgs e)
        {
            rubro = "Transporte";
            Navigation.PushAsync(new ListaServicio(rubro));
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            rubro = "Alquiler de vehiculos";
            Navigation.PushAsync(new ListaServicio(rubro));
        }

        private void BtnVehiculos_Clicked(object sender, EventArgs e)
        {
            rubro = "Alquiler de vehiculos";
            Navigation.PushAsync(new ListaServicio(rubro));
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            rubro = "Mantenimiento";
            Navigation.PushAsync(new ListaServicio(rubro));
        }

        private void BtnMantenimiento_Clicked(object sender, EventArgs e)
        {
            rubro = "Mantenimiento";
            Navigation.PushAsync(new ListaServicio(rubro));
        }
    }
}
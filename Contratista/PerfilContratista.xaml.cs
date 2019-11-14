using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Contratista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PerfilContratista : ContentPage
	{
        private string queryrubro;
        int Numero_telefono = 0;
        public PerfilContratista(int id_contratista, string nombre, string apellido_paterno, string apellido_materno, int telefono, string foto,
                                 string rubro, decimal calificacion, string descripcion)
        {
            InitializeComponent();
            queryrubro = rubro;
            Numero_telefono = telefono;
            nombretxt.Text = nombre + " " + apellido_paterno + " " + apellido_materno;
            txtdescripcion.Text = descripcion;
            imgPerfil.Source = "http://dmrbolivia.online" + foto;
            txtTelefono.Text = telefono.ToString();
            califtxt.Text = calificacion.ToString();
            rubrotxt.Text = rubro;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open(Numero_telefono.ToString());
            }
            catch (Exception err)
            {
                await DisplayAlert("ERROR", err.ToString(), "OK");
            }
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                Datos.Chat.Open("+591" + Numero_telefono, " ");
            }
            catch (Exception err)
            {
                await DisplayAlert("Error", err.Message, "OK");
            }
        }
    }
}
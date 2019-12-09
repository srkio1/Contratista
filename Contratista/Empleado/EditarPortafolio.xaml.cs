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
    public partial class EditarPortafolio : ContentPage
    {
        int IdPortafolio;
        string NombreP;
        string Imagen_1P;
        string Imagen_2P;
        string Imagen_3P;
        string Imagen_4P;
        string Imagen_5P;
        string Imagen_6P;
        string Imagen_7P;
        int IdProfesional;
        int imgPick;
        public EditarPortafolio(int id_portafolio, string nombre, string imagen_1, string imagen_2, string imagen_3, string imagen_4, string imagen_5, string imagen_6,
                                 string imagen_7, int id_profesional)
        {
            InitializeComponent();
            IdPortafolio = id_portafolio;
            NombreP = nombre;
            Imagen_1P = imagen_1;
            Imagen_2P = imagen_2;
            Imagen_3P = imagen_3;
            Imagen_4P = imagen_4;
            Imagen_5P = imagen_5;
            Imagen_6P = imagen_6;
            Imagen_7P = imagen_7;
            IdProfesional = id_profesional;
            txtTitulo.Text = NombreP;
            img_1.Source = "http://dmrbolivia.online" + Imagen_1P;
            img_2.Source = "http://dmrbolivia.online" + Imagen_2P;
            img_3.Source = "http://dmrbolivia.online" + Imagen_3P;
            img_4.Source = "http://dmrbolivia.online" + Imagen_4P;
            img_5.Source = "http://dmrbolivia.online" + Imagen_5P;
            img_6.Source = "http://dmrbolivia.online" + Imagen_6P;
            img_7.Source = "http://dmrbolivia.online" + Imagen_7P;

            if (imagen_1 == null)
            {
                btnImg1.Text = "AGREGAR";
            }
            else
            {
                btnImg1.Text = "BORRAR";
            }

            if (imagen_2 == null)
            {
                btnImg2.Text = "AGREGAR";
            }
            else
            {
                btnImg2.Text = "BORRAR";
            }

            if (imagen_3 == null)
            {
                btnImg3.Text = "AGREGAR";
            }
            else
            {
                btnImg3.Text = "BORRAR";
            }

            if (imagen_4 == null)
            {
                btnImg4.Text = "AGREGAR";
            }
            else
            {
                btnImg4.Text = "BORRAR";
            }

            if (imagen_5 == null)
            {
                btnImg5.Text = "AGREGAR";
            }
            else
            {
                btnImg5.Text = "BORRAR";
            }

            if (imagen_6 == null)
            {
                btnImg6.Text = "AGREGAR";
            }
            else
            {
                btnImg6.Text = "BORRAR";
            }

            if (imagen_7 == null)
            {
                btnImg7.Text = "AGREGAR";
            }
            else
            {
                btnImg7.Text = "BORRAR";
            }

        }

        private void BtnImg1_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new SubirFoto(IdPortafolio));
        }

        private async void BtnImg3_Clicked(object sender, EventArgs e)
        {
            imgPick = 3;
            await Navigation.PushAsync(new SubirFoto(imgPick, IdPortafolio, NombreP, Imagen_1P, Imagen_2P, Imagen_3P, Imagen_4P, Imagen_5P, Imagen_6P, Imagen_7P, IdProfesional));
        }

        private async void BtnImg4_Clicked(object sender, EventArgs e)
        {
            imgPick = 4;
            await Navigation.PushAsync(new SubirFoto(imgPick, IdPortafolio, NombreP, Imagen_1P, Imagen_2P, Imagen_3P, Imagen_4P, Imagen_5P, Imagen_6P, Imagen_7P, IdProfesional));
        }

        private async void BtnImg5_Clicked(object sender, EventArgs e)
        {
            imgPick = 5;
            await Navigation.PushAsync(new SubirFoto(imgPick, IdPortafolio, NombreP, Imagen_1P, Imagen_2P, Imagen_3P, Imagen_4P, Imagen_5P, Imagen_6P, Imagen_7P, IdProfesional));
        }

        private async void BtnImg6_Clicked(object sender, EventArgs e)
        {
            imgPick = 6;
            await Navigation.PushAsync(new SubirFoto(imgPick, IdPortafolio, NombreP, Imagen_1P, Imagen_2P, Imagen_3P, Imagen_4P, Imagen_5P, Imagen_6P, Imagen_7P, IdProfesional));
        }

        private async void BtnImg7_Clicked(object sender, EventArgs e)
        {
            imgPick = 7;
            await Navigation.PushAsync(new SubirFoto(imgPick, IdPortafolio, NombreP, Imagen_1P, Imagen_2P, Imagen_3P, Imagen_4P, Imagen_5P, Imagen_6P, Imagen_7P, IdProfesional));
        }
    }
}
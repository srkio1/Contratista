using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using System.Windows.Input;


namespace Contratista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Publicidad : ContentPage
	{
        public Publicidad ()
		{
			InitializeComponent ();
            GetScrol();
            
        }
        private void GetScrol()
        {
            List<CustomData> GetDataSource()
            {
                List<CustomData> list = new List<CustomData>();
                list.Add(new CustomData("http://dmrbolivia.online/api_contratistas/images/cemento1.jpg"));
                list.Add(new CustomData("http://dmrbolivia.online/api_contratistas/images/clavos1.jpg"));
                list.Add(new CustomData("http://dmrbolivia.online/api_contratistas/images/ladrillo1.jpg"));
                list.Add(new CustomData("http://dmrbolivia.online/api_contratistas/images/708060366Alquimaqui7_1.jpg"));
                list.Add(new CustomData("http://dmrbolivia.online/api_contratistas/images/promo_20.jpg"));

                return list;
            }

            carousel1.ItemsSource = GetDataSource();
        }
        
    }
}
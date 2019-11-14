using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista.Feed_Back
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactanosCliente : ContentPage
	{
		public ContactanosCliente ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratista.Datos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratista.Empleado
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class listacurriculumprofesional : ContentPage
	{
		public listacurriculumprofesional ()
		{
			InitializeComponent ();
		}

        private static IEnumerable<PdfDocEntity> GetPdfs()
        {
            return new[]
            {
                new PdfDocEntity
                {
                    Url = "http://dmrbolivia.online/curriculum/RN_doc.pdf",
                    FileName = "pptdemo2.pdf"
                },
            };
        }

        private void PdfListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e?.SelectedItem == null)
            {
                return;
            }

            var pdfDocEntity = e.SelectedItem as PdfDocEntity;
            if (pdfDocEntity != null)
            {
                Navigation.PushAsync(new PdfDocumentView(pdfDocEntity));
            }

            PdfListView.SelectedItem = null;
        }
    }
}
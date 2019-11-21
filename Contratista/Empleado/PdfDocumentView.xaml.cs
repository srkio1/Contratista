﻿using System;
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
	public partial class PdfDocumentView : ContentPage
	{
        private readonly PdfDocEntity _pdfDocEntity;

		public PdfDocumentView (PdfDocEntity pdfDocEntity)
		{
			InitializeComponent ();
            Title = pdfDocEntity.FileName;
            _pdfDocEntity = pdfDocEntity;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            SetBusyIndicator(true);

            if (await FileManager.ExistsAsync(_pdfDocEntity.FileName) == false)
            {
                await FileManager.DownloadDocumentsAsync(_pdfDocEntity);
            }
            PdfDocView.Uri = FileManager.GetFilePathFromRoot(_pdfDocEntity.FileName);

            SetBusyIndicator(false);
        }
            private void SetBusyIndicator(bool isBusyIndicatorIsVisible) => BusyIndicator.IsRunning = BusyIndicator.IsVisible = isBusyIndicatorIsVisible;
        
    }
}
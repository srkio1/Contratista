using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Contratista
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTU5NjYxQDMxMzcyZTMzMmUzMFpacTFIMDFDTmw1TWhBL1haUy9FNS81Q0wyVjZjQ29lTDZvRFByTUp2WTg9");
            InitializeComponent();

            MainPage = new NavigationPage(new Index());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

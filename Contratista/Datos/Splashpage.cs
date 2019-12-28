using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Contratista.Datos
{
    public class Splashpage : ContentPage
    {
        Image splashImage;

        public Splashpage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "icon_app_1.png",
                WidthRequest = 200,
                HeightRequest = 200
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#429de3");
            this.Content = sub;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 1000); //Time-consuming processes such as initialization
            await splashImage.ScaleTo(0.5, 1000);
            await splashImage.ScaleTo(1, 1000); //Time-consuming processes such as initialization
            await splashImage.ScaleTo(0.5, 999);
            
            Application.Current.MainPage = new NavigationPage(new Index());    //After loading  MainPage it gets Navigated to our new Page
        }

    }
}

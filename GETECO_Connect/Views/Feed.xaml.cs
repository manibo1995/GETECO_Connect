using System;
using System.Collections.Generic;
using Xamanimation;
using Xamarin.Forms;

namespace GETECO_Connect.Views
{
    public partial class Feed : ContentPage
    {
        public Feed()
        {
            InitializeComponent();
            this.BindingContext = new Viewmodels.FeedViewmodel("");
            NavigationPage.SetHasNavigationBar(this, false);

        }


        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (Math.Round(((CarouselView)sender).Scale, 1) != 1.1)
            {
                ((CarouselView)sender).Animate(new ScaleToAnimation { Duration = "1", Scale = 1.2 });
                ((CarouselView)sender).Animate(new ScaleToAnimation { Duration = "10000", Scale = 1.1 });
            }
            else
            {
                ((CarouselView)sender).Animate(new ScaleToAnimation { Duration = "1", Scale = 1.1 });
                ((CarouselView)sender).Animate(new ScaleToAnimation { Duration = "10000", Scale = 1.2 });
            }



            //((ContentView)e.SelectedItem).ScaleTo(1.3);
            //((ContentView)e.SelectedItem).Animate(new TranslateToAnimation { Duration = "10000", TranslateX = 100 });
            //((CarouselView)sender).ScaleTo(1.3);
            //((CarouselView)sender).Animate(new TranslateToAnimation { Duration = "10000", TranslateX = 100 });
            //((Image)sender).Animate(new HeartAnimation());
        }
        void Handle_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new Views.FeedDetail(((Models.SingleFeed)((Grid)sender).BindingContext).id)));
        }
    }
}

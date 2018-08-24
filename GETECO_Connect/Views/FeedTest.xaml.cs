using System;
using System.Collections.Generic;
using Xamanimation;
using Xamarin.Forms;

namespace GETECO_Connect.Views
{
    public partial class FeedTest : CarouselPage
    {
        
        public FeedTest()
        {
            InitializeComponent();

            this.BindingContext = new Viewmodels.FeedViewmodel("");
            //foreach (var item in ((Viewmodels.FeedViewmodel)this.BindingContext).Pages)
            //{
              //  Children.Add(new NavigationPage(item));
            //}
        }



        void Handle_CurrentPageChanged(object sender, System.EventArgs e)
        {
            //((ContentPage)((FeedTest)sender).SelectedItem)
            if (Math.Round(((FeedTest)sender).Scale,1)!=1.0)
            {
                ((FeedTest)sender).Animate(new ScaleToAnimation { Duration = "1", Scale = 1.3 });
                ((FeedTest)sender).Animate(new ScaleToAnimation { Duration = "5000", Scale = 1 });
            }
            else
            {
                ((FeedTest)sender).Animate(new ScaleToAnimation { Duration = "1", Scale = 1 });
                ((FeedTest)sender).Animate(new ScaleToAnimation{Duration="5000",Scale=1.3});
            }
            //((FeedTest)sender).Scale=1;            
            //((FeedTest)sender).ScaleTo(1.5);
            //((FeedTest)sender).Animate(new JumpAnimation{Duration="10000"});
            //((FeedTest)sender).Animate(new ScaleToAnimation { Duration = "10000", Scale = 1 });
            //throw new NotImplementedException();
        }


      
    }
}

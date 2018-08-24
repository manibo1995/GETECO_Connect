using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GETECO_Connect.Views
{
    public partial class FeedDetail : ContentPage
    {
        public FeedDetail(string single_id)
        {
            InitializeComponent();
            this.BindingContext = new Viewmodels.FeedViewmodel(single_id);
            //((Viewmodels.FeedViewmodel)this.BindingContext).SingleFeed = ((Viewmodels.FeedViewmodel)this.BindingContext).Feed.Where(a => a.id == single_id).SingleOrDefault();
            //DisplayAlert("Hi", ((Viewmodels.FeedViewmodel)this.BindingContext).Text, "ok");
        }
    }
}

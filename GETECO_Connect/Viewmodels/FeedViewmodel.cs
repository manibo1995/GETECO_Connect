using System.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace GETECO_Connect.Viewmodels
{
    public class FeedViewmodel : INotifyPropertyChanged
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged("Text"); }
        }

        private Image img;
        public Image Img
        {
            get { return img; }
            set { img = value; OnPropertyChanged("Img"); }
        }

        private ObservableCollection<ContentPage> pages;
        public ObservableCollection<ContentPage> Pages
        {
            get { return pages; }
            set { pages = value; OnPropertyChanged("Pages"); }
        }
        private Models.SingleFeed singlefeed;
        public Models.SingleFeed SingleFeed
        {
            get { return singlefeed; }
            set { singlefeed = value; OnPropertyChanged("SingleFeed"); }
        }


        private ObservableCollection<Models.SingleFeed> feed;
        public ObservableCollection<Models.SingleFeed> Feed
        {
            get { return feed; }
            set { feed = value; OnPropertyChanged("Feed"); }
        }
        private string feedString;
        public string FeedString
        {
            get { return feedString; }
            set { feedString = value; OnPropertyChanged("FeedString"); }
        }
        public FeedViewmodel(string single_id)
        {
            this.Pages = new ObservableCollection<ContentPage>();


            this.FeedString = GetFeedAsString(single_id);

            this.Feed = new ObservableCollection<Models.SingleFeed>();
            var temp = GetFeed(single_id);
            foreach (var item in temp.feeds)
            {
                this.Feed.Add(new Models.SingleFeed
                {
                    id = item.id,
                    headline1 = item.headline1,
                    headline2 = item.headline2,
                    picture1 = Globals.Standards.BaseUrl + item.picture1,
                    picture2 = Globals.Standards.BaseUrl + item.picture2,
                    picture3 = Globals.Standards.BaseUrl + item.picture3,
                    rubrik = item.rubrik,
                    serverVideo = Globals.Standards.BaseUrl + item.serverVideo,
                    text = item.text,
                    timestamp = item.timestamp,
                    video = Globals.Standards.BaseUrl + item.video
                });
            }
            this.Pages = GetPages(Feed);
            if (single_id!="")
            {
                this.Text = Feed[0].text;
            }

        }


        public string GetFeedAsString(string single_id)
        {
            string sendString = Globals.Commands.getFeed(single_id);
            return Globals.Methods.CallService(sendString).ToString();
        }
        public Models.Feeds GetFeed(string single_id)
        {
            string sendString = Globals.Commands.getFeed(single_id);
            var answer = Globals.Methods.CallService(sendString);

            return JsonConvert.DeserializeObject<Models.Feeds>(answer);

        }

        public ObservableCollection<ContentPage> GetPages(ObservableCollection<Models.SingleFeed> feed){
            var temp = new ObservableCollection<ContentPage>();
            foreach (var item in feed)
            {
                var img = new Image
                {
                    Source = item.picture1,
                };
                var lbl = new Label
                {
                    Text = item.headline1
                };
                Grid.SetRow(img, 0);
                Grid.SetRow(lbl, 1);
                Grid.SetRowSpan(img, 3);
                var grid = new Grid{
                    RowDefinitions ={
                        new RowDefinition { Height = GridLength.Star },
                        new RowDefinition { Height = new GridLength(40) },  
                        new RowDefinition { Height = new GridLength(40) },  
                    }
                };
                grid.Children.Add(img);
                grid.Children.Add(lbl);
                temp.Add(new ContentPage
                {
                    Content=grid
                });
            }
            return temp;
        }
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion PropertyChanged

    }

}

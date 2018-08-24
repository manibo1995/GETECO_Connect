using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GETECO_Connect.Models
{
    public class MasterPageCell:ViewCell
    {
        public MasterPageCell()
        {
            var Icon = new Image
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Aspect = Aspect.AspectFill,
                HeightRequest = 18,
                WidthRequest=18
            };
            Icon.SetBinding(Image.SourceProperty, "IconSource");
            var TitleLabel = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                FontSize = 18

            };
            TitleLabel.SetBinding(Label.TextProperty, "Title");
            TitleLabel.SetBinding(Label.TextColorProperty, "TextColor");
            var CellLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(20, 0, 0, 0),
                Children = { Icon, TitleLabel }
            };
            this.View = CellLayout;
        }
    }
}

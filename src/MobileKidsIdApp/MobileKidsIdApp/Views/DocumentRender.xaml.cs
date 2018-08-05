using MobileKidsIdApp.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileKidsIdApp.Views
{
	public partial class DocumentRender : ContentPage
    {
		public DocumentRender()
		{
            Padding = new Thickness(0, 20, 0, 0);
            Content = new StackLayout
            {
                Children = {
                new DocumentWebView
                {
                    Uri = "MissingChildProfile.pdf",
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                }
            }
            };
        }
	}
}
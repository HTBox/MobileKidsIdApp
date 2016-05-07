using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MobileKidsIdApp
{
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void DisplayContentMenu(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContentMenu());
        }
    }
}

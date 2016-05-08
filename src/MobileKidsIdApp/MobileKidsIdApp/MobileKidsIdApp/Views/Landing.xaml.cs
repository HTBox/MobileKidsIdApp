using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MobileKidsIdApp.Views
{
    public partial class Landing : ContentPage
    {
        public Landing()
        {
            InitializeComponent();
        }

        private void DisplayContentMenu(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StaticContent());
        }
    }
}
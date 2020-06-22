using System;
using System.Globalization;
using MobileKidsIdApp.Models;
using Xamarin.Forms;

namespace MobileKidsIdApp
{
    public class GenderToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Gender gender)
            {
                return gender switch
                {
                    Gender.Male => Color.SkyBlue,
                    Gender.Female => Color.HotPink,
                    _ => Color.Default,
                };
            }

            return Color.Default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

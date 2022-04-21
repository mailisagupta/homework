using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace CanRackDisplay
{
    class FlavorNameToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Image a = new Image();

            BitmapImage bi3 = new BitmapImage();

            switch (value.ToString())
            {
                case "ColaCola":
                    bi3.UriSource = new Uri(@".\Images\CocaCola.png", UriKind.Relative);
                    a.Source = bi3;

                    break;
                case "Dew":
                    bi3.UriSource = new Uri(@".\Images\Dew.png", UriKind.Relative);
                    a.Source = bi3;
                    break;
                case "Gingerale":
                    bi3.UriSource = new Uri(@".\Images\Gingerale.png", UriKind.Relative);
                    a.Source = bi3;
                    break;
                default:
                    break;
            }
            return a.Source;



        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace VendingMachine
{
    class FlavorNameToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Image a = new Image();

            //BitmapImage bi3 = new BitmapImage();

            switch (value.ToString())
            {
                case "CocaCola":
                    //bi3.UriSource = new Uri(@"\Images\CocaCola.png", UriKind.Relative);
                    a.Source = new BitmapImage(new Uri(@"\Images\CocaCola.png", UriKind.Relative));

                    break;
                case "Dew":
                    ///bi3.UriSource = new Uri(@"\Images\Dew.png", UriKind.Relative);
                    a.Source = new BitmapImage(new Uri(@"\Images\Dew.png", UriKind.Relative));
                    break;
                case "Gingerale":
                    ///bi3.UriSource = new Uri(@"\Images\Gingerale.png", UriKind.Relative);
                    a.Source = new BitmapImage(new Uri(@"\Images\Gingerale.png", UriKind.Relative));
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

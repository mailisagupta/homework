/// Assignment 01
/// Author: Gupta, Mailisa mailisa
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VendLib;

namespace VendingMachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Assignment 01
    /// Author: Gupta, Mailisa
    public partial class MainWindow : Window
    {
       
        

        public MainWindow()
        {
            InitializeComponent();
           

        }

        

        private void OnImageButtonClickCocaCola(object sender, RoutedEventArgs e)
        {


            

            (DataContext as ViewModel).FromFlavorButton("CocaCola");

        }

        private void OnImageButtonClickDew(object sender, RoutedEventArgs e)
        {
            (DataContext as ViewModel).FromFlavorButton("Dew");

            

        }

        private void OnImageButtonClickGingerale(object sender, RoutedEventArgs e)
        {
            (DataContext as ViewModel).FromFlavorButton("Gingerale");

           




        }


        private void OnButtonClickBalanceHere(object sender, RoutedEventArgs e)
        {
           

            (DataContext as ViewModel).ReturnCoins();
        }

        private void OnButtonClickNickel(object sender, RoutedEventArgs e)
        {
           
            (DataContext as ViewModel).InsertCoin(0.05M);
        }

        private void OnButtonClickDime(object sender, RoutedEventArgs e)
        {
            
            (DataContext as ViewModel).InsertCoin(0.10M);
        }

        private void OnButtonClickHalfDollar(object sender, RoutedEventArgs e)
        {
            
            (DataContext as ViewModel).InsertCoin(0.50M);
        }

        private void OnButtonClickQuarter(object sender, RoutedEventArgs e)
        {
            (DataContext as ViewModel).InsertCoin(0.25M);
        }

        private void Button1(object sender, RoutedEventArgs e)
        {

        }

        private void Button2(object sender, RoutedEventArgs e)
        {

        }
        private void Button3(object sender, RoutedEventArgs e)
        {

        }
    }
}

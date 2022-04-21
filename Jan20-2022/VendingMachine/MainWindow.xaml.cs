/// Assignment 01
/// Author: Gupta, Mailisa mailisa
using System.Windows;
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

        ViewModel a;

        public MainWindow(ViewModel A)
        {
            a = A;
            InitializeComponent();
            DataContext = A;
           

        }

        

        //private void OnImageButtonClickCocaCola(object sender, RoutedEventArgs e)
        //{


            

        //    a.FromFlavorButton("CocaCola");

        //}

        //private void OnImageButtonClickDew(object sender, RoutedEventArgs e)
        //{
        //    a.FromFlavorButton("Dew");

            

        //}

        //private void OnImageButtonClickGingerale(object sender, RoutedEventArgs e)
        //{
        //    a.FromFlavorButton("Gingerale");

           




        //}


        //private void OnButtonClickBalanceHere(object sender, RoutedEventArgs e)
        //{
           

        //    a.ReturnCoins();
        //}

        //private void OnButtonClickNickel(object sender, RoutedEventArgs e)
        //{
           
        //    a.InsertCoin(0.05M);
        //}

        //private void OnButtonClickDime(object sender, RoutedEventArgs e)
        //{
            
        //   a.InsertCoin(0.10M);
        //}

        //private void OnButtonClickHalfDollar(object sender, RoutedEventArgs e)
        //{
            
        //    a.InsertCoin(0.50M);
        //}

        //private void OnButtonClickQuarter(object sender, RoutedEventArgs e)
        //{
        //    a.InsertCoin(0.25M);
        //}

        private void Button1(object sender, RoutedEventArgs e)
        {
            MachineContents machineContents = new();
            machineContents.Load(DataContext as ViewModel);
            machineContents.Show();
            
        }

        private void Button2(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Button3(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)

        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                DragMove();
        }

    }
}

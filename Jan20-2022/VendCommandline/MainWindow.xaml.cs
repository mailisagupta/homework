using System.Windows;
using VendLib;

namespace VendCommandline
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ViewModel vendViewModel)
        {
            InitializeComponent();

            DataContext = vendViewModel;

            
            canRack.DataContext = new CanRackViewModel(vendViewModel._canRack);
            tempCoinBox.DataContext = new CoinBoxViewModel (vendViewModel._CoinBox1);
          
            mainCoinBox.DataContext = new CoinBoxViewModel (vendViewModel._CoinBox2);
            //@Kevin: I dont know how to run this from command line, how can i pass the viewmodel object from command line, i am very confused.
            // i tried to do Exercise 7.3, its not working for me. 

        }
    }
}

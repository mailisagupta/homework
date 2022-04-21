using VendLib;
using System.Windows;

namespace VendingMachine
{
    /// <summary>
    /// Interaction logic for MachineContents.xaml
    /// </summary>
    public partial class MachineContents : Window
    {
        public MachineContents()
        {
            InitializeComponent();
        }
        public void Load(ViewModel vendViewModel)
        {
            DataContext = vendViewModel;
            CanRackView.DataContext = new CanRackViewModel(vendViewModel._canRack);
            TempCoinBoxView.DataContext = new CoinBoxViewModel(vendViewModel._CoinBox1);
            MainCoinBoxView.DataContext = new CoinBoxViewModel(vendViewModel._CoinBox2);
        }
    }
}

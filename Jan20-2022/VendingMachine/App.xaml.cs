using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VendLib;

namespace VendingMachine
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CanRack canRack = new(new List<Can>()
            {
                
                new Can(Flavor.Dew),
                new Can(Flavor.Gingerale),
                new Can(Flavor.Dew),
                new Can(Flavor.Dew),
                new Can(Flavor.Gingerale),
                new Can(Flavor.Gingerale),
                new Can(Flavor.CocaCola),
                new Can(Flavor.CocaCola)
            });
            ICoinBox<Coin> CoinBox1 = new CoinBox<Coin>();
            ICoinBox<Coin> CoinBox2 = new CoinBox<Coin>();
            //decimal sodaPrice = 0.35M;
            //string customerMessage = "Welcome to the Soda Vending Machine";

            ViewModel vendViewModel = new ViewModel(
                canRack,
                CoinBox1,
                CoinBox2
                );

            var mainWindow = new MainWindow(vendViewModel);

            mainWindow.Show();
        }
    }
}

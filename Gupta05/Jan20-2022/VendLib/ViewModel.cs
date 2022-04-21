using CanRackLib;
using CoinLib;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VendLib
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private CanRack _canRack  = new();
        private CoinBox<Coin> _CoinBox1 = new(); //temp
        private CoinBox<Coin> _CoinBox2 = new(); //main
        private decimal _sodaPrice;
        private string _displayMessage;
        private decimal _MoneyInserted;

        public ViewModel()
        {
            DisplayMessage = "Hello!! Click on Buttons below to pay";
        }
        

        public decimal MoneyInserted
        {
            get => _CoinBox1.ValueOf;
            set
            {
                _MoneyInserted = value;
                InvokeEventPropertyChange();
            }
        }
        public string DisplayMessage
        {
            get => _displayMessage;
            set
            {
                _displayMessage = value;
                InvokeEventPropertyChange();
            }
        }

        public decimal SodaPrice(Flavor f)
        {
            switch (f)
            {
                case Flavor.CocaCola:
                    _sodaPrice = 0.50M;
                    break;
                case Flavor.Dew:
                    _sodaPrice = 0.40M;
                    break;
                case Flavor.Gingerale:
                    _sodaPrice = 0.30M;
                    break;

            }
            return _sodaPrice;
        }

        public bool GingeraleButtonIsEnabled => CheckButtonIsEnabled(Flavor.Gingerale);
        public bool DewButtonIsEnabled=> CheckButtonIsEnabled(Flavor.Dew);
        public bool CocaColaButtonIsEnabled=> CheckButtonIsEnabled(Flavor.CocaCola);

        private bool CheckButtonIsEnabled( Flavor f )
        {
            bool a = false;
            if (_canRack.HasACanOf(f) && EnoughMoney(f))
            {
                a = true;
            }
            return a;
        }

        private bool EnoughMoney(Flavor f)
        {
            bool a = false;
            
            if (_CoinBox1.ValueOf >= SodaPrice(f)) { a = true; }
            return a;

        }


        public void InsertCoin(decimal coinValue)
        {
            _CoinBox1.Deposit(new Coin(coinValue));
            decimal TotalMoney = _CoinBox1.ValueOf;
            if (TotalMoney < 0.30M)
            {
                DisplayMessage = $"Please insert more Money";
            }
            else if (TotalMoney >= 0.30M && TotalMoney < 0.40M)
            {
                
                UpdateButtonStatus();
                DisplayMessage = $"You have entered  {TotalMoney.ToString():c}. You can select Gingerale";
            }
            else if (TotalMoney >= 0.40M && TotalMoney < 0.50M)
            {
                
                UpdateButtonStatus();
                DisplayMessage = $"You have entered  {TotalMoney.ToString():c}. You can select Dew or Gingerale";
            }
            else if (TotalMoney >= 0.50M)
            {
                UpdateButtonStatus();
                DisplayMessage = $"You have entered  {TotalMoney.ToString():c}. Please select any flavor";
            }
            InvokeEventPropertyChange("MoneyInserted");
        }

        public void FromFlavorButton(string f)
        {
            Coin cd = new(Coin.Denomination.Dime);
            Coin cn = new(Coin.Denomination.Nickel);
            Flavor flavorValue = FlavorOps.ConvertStringToFlavor(f);
            decimal MoneyRemaining = MoneyInserted - SodaPrice(flavorValue);
            if (EnoughMoney(flavorValue) && _canRack.HasACanOf(flavorValue))
            {
                _canRack.RemoveACanOf(flavorValue);
                
                if (MoneyRemaining > 0M && MoneyRemaining < 0.30M)
                {
                    DisplayMessage = $"Enjoy your soda! Insert more money to purchase more soda or Collect your balance: {MoneyRemaining:c} by clicking on Coin Return";
                    
                }
                else if (MoneyRemaining >= 0.30M)
                {
                    DisplayMessage = $"Enjoy your soda! Make another selection to purchase more soda or Collect your balance: {MoneyRemaining:c} by clicking on Coin Return";
                    
                }
                else
                {
                    DisplayMessage = $"Enjoy your soda!";
                }
                _CoinBox1.Balance(_CoinBox2, SodaPrice(flavorValue), cd, cn); ////@Kevin, this Balance function is in CoinLib> CoinBox class. I have created it so that transcation does not end after one sode is purchased. i wanted to continue buying until customer wants.
                UpdateButtonStatus();
                InvokeEventPropertyChange("MoneyInserted");


            }

        }
       
        public decimal ReturnCoins()
        {
            decimal result = MoneyInserted;
            if (result > 0M)
            {
                DisplayMessage = $"Please collect your money: {result:c}"; 
                _CoinBox1.Withdraw(result);
                UpdateButtonStatus();
                InvokeEventPropertyChange("MoneyInserted");

            }
            else
            {
                DisplayMessage = $"There is no money to return!";
                UpdateButtonStatus();
                InvokeEventPropertyChange("MoneyInserted");
            }
            return result;
        }


        private void UpdateButtonStatus()
        {
            InvokeEventPropertyChange("GingeraleButtonIsEnabled");
            InvokeEventPropertyChange("DewButtonIsEnabled");
            InvokeEventPropertyChange("CocaColaButtonIsEnabled");
        }


        private void InvokeEventPropertyChange([CallerMemberName] string a = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(a));
        }

    }
 
        
    
}

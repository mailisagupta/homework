
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;



namespace VendLib
{
    public class CoinBoxViewModel : ICoinBoxViewModel
    {
        public ObservableCollection<CoinDisplayData> ListCoinContent { get; set; }

        private ICoinBox<Coin> _cbox;

        public CoinBoxViewModel(ICoinBox<Coin> cbox)
        {
            _cbox = cbox;
            //    new CoinBox<Coin>(new()
            //{
            //    //new Coin(Coin.Denomination.Nickel),
            //    new Coin(Coin.Denomination.Quarter),
            //    new Coin(Coin.Denomination.Quarter),
            //    new Coin(Coin.Denomination.Quarter),
            //    new Coin(Coin.Denomination.HalfDollar),
            //    new Coin(Coin.Denomination.Dime),
            //    new Coin(Coin.Denomination.HalfDollar)
            //});

            PopulateData();

        }

        private void PopulateData()
        {
            ListCoinContent = new();
            CoinDisplayData a = new CoinDisplayData();
            CoinDisplayData cNickel = new CoinDisplayData();
            CoinDisplayData cQuarter = new CoinDisplayData();
            CoinDisplayData cHalfDollar = new CoinDisplayData();
            CoinDisplayData cDime = new CoinDisplayData();
            cNickel.CoinDenomination = "Nickel";
            cQuarter.CoinDenomination = "Quarter";
            cHalfDollar.CoinDenomination = "HalfDollar";
            cDime.CoinDenomination = "Dime";
            foreach (Coin m in _cbox.Where(c => c.ToString() == "Nickel"))
            {

                cNickel.DollarValueOfCoin = cNickel.DollarValueOfCoin + m.ValueOf;
                cNickel.NumberOfCoins = cNickel.NumberOfCoins + 1;
            }

            foreach (Coin m in _cbox.Where(c => c.ToString() == "Quarter"))
            {

                cQuarter.DollarValueOfCoin = cQuarter.DollarValueOfCoin + m.ValueOf;
                cQuarter.NumberOfCoins = cQuarter.NumberOfCoins + 1;
            }

            foreach (Coin m in _cbox.Where(c => c.ToString() == "HalfDollar"))
            {

                cHalfDollar.DollarValueOfCoin = cHalfDollar.DollarValueOfCoin + m.ValueOf;
                cHalfDollar.NumberOfCoins = cHalfDollar.NumberOfCoins + 1;
            }

            foreach (Coin m in _cbox.Where(c => c.ToString() == "Dime"))
            {

                cDime.DollarValueOfCoin = cDime.DollarValueOfCoin + m.ValueOf;
                cDime.NumberOfCoins = cDime.NumberOfCoins + 1;
            }

            //foreach (Coin c in _cbox)
            //{ 
            //    String coinname = c.ToString();

            //    switch (coinname)
            //    {
            //        case "Nickel":
            //            cNickel.CoinDenomination = "Nickel";
            //            cNickel.DollarValueOfCoin = cNickel.DollarValueOfCoin + c.ValueOf;
            //            cNickel.NumberOfCoins = cNickel.NumberOfCoins + 1;
            //            break;
            //        case "Quarter":
            //            cQuarter.CoinDenomination = "Quarter";
            //            cQuarter.DollarValueOfCoin = cQuarter.DollarValueOfCoin + c.ValueOf;
            //            cQuarter.NumberOfCoins = cQuarter.NumberOfCoins + 1;
            //            break;
            //        case "HalfDollar":
            //            cHalfDollar.CoinDenomination = "HalfDollar";
            //            cHalfDollar.DollarValueOfCoin = cHalfDollar.DollarValueOfCoin + c.ValueOf;
            //            cHalfDollar.NumberOfCoins = cHalfDollar.NumberOfCoins + 1;
            //            break;
            //        case "Dime":
            //            cDime.CoinDenomination = "Dime";
            //            cDime.DollarValueOfCoin = cDime.DollarValueOfCoin + c.ValueOf;
            //            cDime.NumberOfCoins = cDime.NumberOfCoins + 1;
            //            break;
            //        default:
            //            break;
            //    }

            //}
            // if (cNickel.CoinDenomination is not null)
            //{
            ListCoinContent.Add(cNickel);

            //}

            //if (cQuarter.CoinDenomination is not null)
            //{
            ListCoinContent.Add(cQuarter);
            //}

            //if (cHalfDollar.CoinDenomination is not null)
            //{
            ListCoinContent.Add(cHalfDollar);
            //}
            //if (cDime.CoinDenomination is not null)
            //{
            ListCoinContent.Add(cDime);
            //}
            a.NumberOfCoins = _cbox.Count();
            a.CoinDenomination = "Total";
            a.DollarValueOfCoin = _cbox.ValueOf;
            ListCoinContent.Add(a);

        }

    }
}

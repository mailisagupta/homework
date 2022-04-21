using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VendLib
{
    public interface ICoinBoxViewModel
    {
        ObservableCollection<CoinDisplayData> ListCoinContent { get; set; }
    }
}
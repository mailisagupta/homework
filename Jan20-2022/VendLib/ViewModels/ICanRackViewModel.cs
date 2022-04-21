using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VendLib
{
    public interface ICanRackViewModel
    {
        DelegateCommand<string> CanDetailCommand { get; }
        string CanDetailInfo { get; set; }
        ObservableCollection<string> Cans { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void InvokePropertyChanged([CallerMemberName] string propertyname = null);
    }
}
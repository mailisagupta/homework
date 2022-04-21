
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VendLib
{
    public class CanRackViewModel : INotifyPropertyChanged, ICanRackViewModel
    {
        //CanRack _c = new CanRack();
        public ICanRack _c { get; set; }
        DelegateCommand<string> CanRackReplenishCommand { get; set; }
        public ObservableCollection<string> Cans { get; set; } = new();

        private string _canDetailInfo;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public string CanDetailInfo
        {
            get { return _canDetailInfo; }
            set
            {
                _canDetailInfo = value;
                InvokePropertyChanged();
            }
        }

        public DelegateCommand<string> CanDetailCommand { get; }



        public void InvokePropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public CanRackViewModel(ICanRack c)
        {
            _c = c;
            Cans = StringValueOfCanInCanRack(_c);
            CanDetailCommand = new DelegateCommand<string>((f) => CanDetailInfo = $"Can Flavor: {f}");
            CanRackReplenishCommand = new DelegateCommand<string>((f) =>
                {
                    _c.FillTheCanRack();
                    StringValueOfCanInCanRack(_c);
                });

        }

        private ObservableCollection<string> StringValueOfCanInCanRack(ICanRack canRack)
        {
            ObservableCollection<string> a = new ObservableCollection<string>();
            foreach (Flavor f in FlavorOps.AllFlavors)
            {
                for (int i = 0; i < canRack[f]; i++)
                {
                    a.Add(f.ToString());
                }
            }
            return a;
        }
    }
}

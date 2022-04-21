using CanRackLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanRackDisplay
{
    class CanRackViewModel
    {
        CanRack _c = new CanRack();

        public ObservableCollection<string> Cans { get; set; } = new();


        public CanRackViewModel()
        {
            Cans = StringValueOfCanInCanRack(_c);

        }

        private ObservableCollection<string> StringValueOfCanInCanRack(CanRack canRack)
        { 
            ObservableCollection<string> a = new ObservableCollection<string>();
            foreach(Flavor f in FlavorOps.AllFlavors)
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

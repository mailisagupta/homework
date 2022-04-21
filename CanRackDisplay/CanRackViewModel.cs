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
        CanRack c = new CanRack();
        public ObservableCollection<string> Can { get; set; }
        public CanRackViewModel()
        {
           
        }
    }
}

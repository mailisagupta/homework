using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes_example
{
    class Class1
    {
        
            static void Main()
            {
                // var is used as a shorthand for Television (or whatever type is on the right-hand side)
                television tv = new television();

                if (tv.IsOn() == false)
                {
                    tv.TurnOn();
                }

                tv.ChangeChannel(3);

                tv.IncreaseVolume();
                tv.IncreaseVolume();
                tv.IncreaseVolume();
                tv.IncreaseVolume();

                tv.TurnOff();
            Console.WriteLine("{0} ", tv.IsOn());
            Console.ReadLine();
            }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes_example
{
    class Contact
    {
        public string FirstName;
        public string LastName;
        public int Age;
        private string FullName;
        public string GetFullName()
        {
            FullName = FirstName + ' ' + LastName;
            return FullName;
        }
    }
}

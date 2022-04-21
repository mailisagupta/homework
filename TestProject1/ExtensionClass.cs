using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public static class ExtensionClass
    {
        public static void AssertExtension(this Assert a , Gigo g)
        {
            Assert.AreEqual(42, g.Consume("Answer"));
        }
    }
}

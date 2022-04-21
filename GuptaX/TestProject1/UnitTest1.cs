using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Gigo g;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Initialmethod()
        {
            Random r = new Random();
            int a = r.Next();
            g = new Gigo(a);
            TestContext.WriteLine("Initial value : {0}", a);
        }

        [TestMethod]
        public void Senerio1()
        {
            Assert.AreEqual(0, g.Consume(0));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Senerio2()
        {
            g.Consume(1.1);
        }

        [DataTestMethod]
        [DataRow("a")]
        [DataRow("e")]
        [DataRow("i")]
        [DataRow("o")]
        [DataRow("u")]
        public void Senerio3(string a)
        {
            TestContext.WriteLine("value under test {0}", a);
            Assert.AreEqual(a.ToUpper(), g.Consume(a));
        }

        [TestMethod]
        [DynamicData(nameof(GetInteger), DynamicDataSourceType.Method)]
        public void Senerio4(int a)
        {
            TestContext.WriteLine("value under test {0}", a);
            if (a % 2 == 0)
                Assert.AreEqual(0, g.Consume(a));

            else
                Assert.AreEqual(a, g.Consume(a));
            
        }


        private static IEnumerable<object[]> GetInteger()
        {
            for (int i = 0; i < 101; i++)
            {

                yield return new object[] { i };
            }
        }

        [TestMethod]
        public void Senerio5()
        {
            Assert.That.AssertExtension(g);
        }


        
    }
}

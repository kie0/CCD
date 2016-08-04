using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umbrechen;

namespace Umbrechen.Tests
{
    [TestClass]
    public class UmbrecherTests
    {
        [TestMethod]
        public void Test_Umbrechen_9()
        {
            string text = "Es blaubt die Nacht,\ndie Sternlein blinken,\nSchneeflöcklein leis hernieder sinken.";
            var cls = new Umbrecher();
            var result = cls.Umbrechen(text, 9);
            Assert.AreEqual("Es blaubt\ndie\nNacht,\ndie\nSternlein\nblinken,\nSchneeflö\ncklein\nleis\nhernieder\nsinken.", result);
        }

        [TestMethod]
        public void Test_Umbrechen_14()
        {
            string text = "Es blaubt die Nacht,\ndie Sternlein blinken,\nSchneeflöcklein leis hernieder sinken.";
            var cls = new Umbrecher();
            var result = cls.Umbrechen(text, 14);
            Assert.AreEqual("Es blaubt die\nNacht, die\nSternlein\nblinken,\nSchneeflöcklei\nn leis\nhernieder\nsinken.", result);
        }

        [TestMethod]
        public void Test_WortLesen_Test1()
        {
            var cls = new Umbrecher();

            var result = cls.WorteLesen("Wort1, Wort2 \nWort3.");
            CollectionAssert.AreEqual(new [] { "Wort1,","Wort2","Wort3." }, result.ToArray());
        }

        [TestMethod]
        public void Test_WorteNormieren_Test1()
        {
            var cls = new Umbrecher();

            var result = cls.WorteNormieren(new[] { "Sternlein" }, 4);
            CollectionAssert.AreEqual(new[] { "Ster", "nlei", "n" }, result.ToArray());
        }

        [TestMethod]
        public void Test_WorteInZeilen_Test1()
        {
            var cls = new Umbrecher();

            var result = cls.WorteInZeilen(new[] { "Ster", "nlei", "n", "so" }, 4);
            CollectionAssert.AreEqual(new[] { "Ster", "nlei", "n so" }, result.ToArray());
        }


        [TestMethod]
        public void Test_WorteInZeilen_Test2()
        {
            var cls = new Umbrecher();

            var result = cls.WorteInZeilen(new[] { "Ster", "nlei", "n", "soso" }, 4);
            CollectionAssert.AreEqual(new[] { "Ster", "nlei", "n","soso" }, result.ToArray());
        }

        [TestMethod]
        public void Test_ZeilenInText_Test1()
        {
            var cls = new Umbrecher();

            var result = cls.ZeilenInText(new[] { "Ster", "nlei", "n", "soso" });
            Assert.AreEqual("Ster\nnlei\nn\nsoso", result);
        }

        [TestMethod]
        public void Test_WortZusammenfügen_Test1()
        {
            var cls = new Umbrecher();

            var result = cls.WorteZusammenfügen(new[] { "A,", "BB", "CCC." }, 3);
            Assert.AreEqual("A,\nBB\nCCC\n." , result);
        }

        [TestMethod]
        public void Test_WortZusammenfügen_Test2()
        {
            var cls = new Umbrecher();

            var result = cls.WorteZusammenfügen(new[] { "A,", "BB", "CCC." }, 5);
            Assert.AreEqual("A, BB\nCCC." , result);
        }

        [TestMethod]
        public void Test_WortZusammenfügen_Test3()
        {
            var cls = new Umbrecher();

            var result = cls.WorteZusammenfügen(new[] { "Sternlein", "so"}, 4);
            Assert.AreEqual("Ster\nnlei\nn so", result);
        }
    }
}

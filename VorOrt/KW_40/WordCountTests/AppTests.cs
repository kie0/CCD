using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCount;

namespace WordCountTests
{
    [TestClass]
    public class AppTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var cli = new Moq.Mock<Cli>().Setup(cli1 => )

            ////new App()
        }

        [TestMethod]
        public void Counter()
        {
            var testInput = "Das ist eine Satz";
            var counter = new Counter();
            var countWords = counter.CountWords(testInput, new string[] {"fff"});
            Assert.AreEqual(4, countWords);
        }

    }
}

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
            var io = new TestIo(new [] {"a"},"a b c" );
            var app = new App(io);
            app.Run();
            Assert.AreEqual("2", io.Output);
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

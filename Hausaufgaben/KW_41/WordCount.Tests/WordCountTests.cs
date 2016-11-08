using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCount.Tests
{
    [TestClass]
    public class WordCountTests
    {
        [TestMethod()] 
        public void KataCountIV()
        {
            var console = new ConsoleMock("Humpty-Dumpty sat on a wall. Humpty-Dumpty had a great fall.");
            var fileSystemMock = new FileSystemMock(
                "Humpty-Dumpty sat on a wall. Humpty-Dumpty had a great fall.",
                new []{"the","a","on","off"});
            var commandLineInterface = new CommandLineMock(null);

            new App(console,fileSystemMock,commandLineInterface).Run();

            Assert.AreEqual(9,console.WriteResultOfCounts.Count);
            Assert.AreEqual(7,console.WriteResultOfCounts.UniqueCount);
        }

        [TestMethod]
        public void KataCountVII()
        {
            
        }
    }
}

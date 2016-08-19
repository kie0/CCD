using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataLoc.Tests
{
    [TestClass]
    public class KataLocTest
    {
        [TestMethod]
        public void CountLOCTest()
        {
            var loc = new Loc();
            Assert.AreEqual(6, loc.CountLOC("1\r\n\r\n// …\r\n2 // …\r\n/* … */\r\n/* … */ 3\r\n\r\n/*\r\n…\r\n*/\r\n4\r\n5 /* …\r\n… */ 6"));
        }
        
        [TestMethod]
        public void CountLoc_1()
        {
            var loc = new Loc();
            Assert.AreEqual(1, loc.CountLOC("a = 0; /* Kommentar */"));
        }

        [TestMethod]
        public void CountLoc_2()
        {
            var loc = new Loc();
            Assert.AreEqual(1, loc.CountLOC("a = 0; /* Kommentar */ b = 2;"));
        }

        [TestMethod]
        public void CountLoc_3()
        {
            var loc = new Loc();
            Assert.AreEqual(1, loc.CountLOC("/* Kommentar1 */ var a = 2;  /* Kommentar2 */"));
        }



        [TestMethod]
        public void RemoveCommentBlocksTest_0()
        {
            var loc = new Loc();
            var lines = new[] { "var a = 2;  /* Ko", "12345", "ar*/ var g = 2;" };
            CollectionAssert.AreEqual(new[] { "var a = 2;  /* Ko", "ar*/ var g = 2;" }, loc.RemoveCommentBlocks(lines).ToArray());
        }

        [TestMethod]
        public void RemoveCommentBlocksTest_1()
        {
            var loc = new Loc();
            var lines = new[] { "var a = 2;  /* Ko", "12345", "ar*/" };
            CollectionAssert.AreEqual(new[] { "var a = 2;  /* Ko" }, loc.RemoveCommentBlocks(lines).ToArray());
        }

        [TestMethod]
        public void RemoveCommentBlocksTest_2()
        {
            var loc = new Loc();
            var lines = new[] { "/* Ko", "12345", "ar*/" };
            CollectionAssert.AreEqual(new string[0], loc.RemoveCommentBlocks(lines).ToArray());
        }

        [TestMethod]
        public void RemoveCommentBlocksTest_3()
        {
            var loc = new Loc();
            var lines = new[] { "/* Ko", "12345", "ar*/ var g = 2;" };
            CollectionAssert.AreEqual(new[] { "ar*/ var g = 2;" }, loc.RemoveCommentBlocks(lines).ToArray());
        }

        [TestMethod]
        public void RemoveCommentBlocksTest_4()
        {
            var loc = new Loc();
            var lines = new[] { " Kommentar */ var g = 2;" };
            CollectionAssert.AreEqual(new[] { " Kommentar */ var g = 2;" }, loc.RemoveCommentBlocks(lines).ToArray());
        }

        [TestMethod]
        public void RemoveCommentInLineTest_0()
        {
            var loc = new Loc();
            Assert.AreEqual(" var g = 2; ", loc.RemoveCommentInLine("/* Kommentar */ var g = 2; /* Kommentar */"));
        }

        [TestMethod]
        public void RemoveCommentInLineTest_1()
        {
            var loc = new Loc();
            Assert.AreEqual(" var g = 2;  /* Teil Kommentar", loc.RemoveCommentInLine("/* Kommentar */ var g = 2; /* Kommentar */ /* Teil Kommentar"));
        }

    }
}


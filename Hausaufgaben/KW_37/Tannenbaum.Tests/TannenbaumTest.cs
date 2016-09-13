using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tannenbaum.Tests
{
    [TestClass]
    public class TannenbaumTest
    {
        [TestMethod]
        public void ZeichnenTest()
        {
            var hoehe = 2;
            IEnumerable<string> lines= Tannenbaum.Zeichnen(hoehe);
            CollectionAssert.AreEqual(
                new []
                {
                    " X ",
                    "XXX",
                    " I "
                },lines.ToArray());
        }

        [TestMethod]
        public void ZweigeZeichnenTest()
        {
            var hoehe = 2;
            IEnumerable<string> lines = Tannenbaum.ZweigeZeichnen(hoehe);
            CollectionAssert.AreEqual(
                new[]
                {
                    " X ",
                    "XXX",
                }, lines.ToArray());
        }

        [TestMethod]
        public void AddStammTest()

        {
            var hoehe = 2;
            var zweige = new[]
            {
                " X ",
                "XXX",
            };
            IEnumerable<string> lines = Tannenbaum.AddStamm(hoehe, zweige);

            CollectionAssert.AreEqual(
            new[]
            {
                " X ",
                "XXX",
                " I "
            }, lines.ToArray());
        }


        [TestMethod]
        public void ZeichnenMitSpitzeTest()
        {
            var hoehe = 2;
            IEnumerable<string> lines = Tannenbaum.ZeichnenMitSpitze(hoehe);
            CollectionAssert.AreEqual(
                new[]
                {
                    " * ",
                    " X ",
                    "XXX",
                    " I "
                }, lines.ToArray());
        }

        [TestMethod]
        public void InsertSpitzeTest()
        {
            var hoehe = 2;
            var baum = new[]
            {
                " X ",
                "XXX",
                " I "
            };
            IEnumerable<string> lines = Tannenbaum.InsertSpitze(hoehe, baum);

            CollectionAssert.AreEqual(
            new[]
            {
                " * ",
                " X ",
                "XXX",
                " I "
            }, lines.ToArray());
        }
    }
}

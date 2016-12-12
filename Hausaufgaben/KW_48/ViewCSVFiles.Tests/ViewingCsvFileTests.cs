using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewCSVFiles.Tests.Mockups;

namespace ViewCSVFiles.Tests
{
    [TestClass]
    public class ViewingCsvFileTests
    {
        private static readonly string[] PersonsCsv = new string[]
        {
            "Name;Age;City",
            "Peter;42;New York",
            "Paul;57;London",
            "Mary;35;Munich",
            "Jaques;66;Paris",
            "Yuri;23;Moscow",
            "Stephanie;47;Stockholm",
            "Nadia;29;Madrid",

        };


        [TestMethod]
        public void FirstTest()
        {
            var result = new []
            {
                "Name |Age|City    |",
                "-----+---+--------+",
                "Peter|42 |New York|",
                "Paul |57 |London  |",
                "Mary |35 |Munich  |",
                "N(ext page, P(revious page, F(irst page, L(ast page, eX(it"
            };

            var console = new ConsoleMockup("f");
            var environmentMockup = new EnvironmentMockup("persons.csv",3);
            var ioMockup = new IoMockup(PersonsCsv);

            var app = new App(
                console,
                ioMockup,  
                environmentMockup);
            
            app.Run();
            CollectionAssert.AreEqual(result, console.Output, StringComparer.InvariantCultureIgnoreCase);
            

        }
    }
}

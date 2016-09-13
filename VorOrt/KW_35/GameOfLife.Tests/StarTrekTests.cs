using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;

namespace GameOfLife.Tests
{
    [TestClass]
    public class StarTrekTests
    {
        [TestMethod]
        public void AcceptanceTest()
        {
            var genZero = new Generation(3,3, 
                new []
                {
                    new []{ true, false, false },
                    new []{ false, true, true } ,
                    new []{ false, false, true }
                }
                );

            var starTrek = new StarTrek();
            var genNext = starTrek.GenerateNextGeneration(genZero);
            var after = genNext.ToList();

            CollectionAssert.AreEqual(
                new[] {
                    false,true,false,
                    false,true,false,
                    false,false,false,},
                after);
        }

        [TestMethod]
        public void GetNeighbourTest()
        {
            var gen = new Generation(3, 3,
                new[]
                    {
                        new []{ true, false, false },
                        new []{ false, true, true } ,
                        new []{ false, false, true }
                    }
                );
            var neighbours = gen.GetNeighbours(0,0);
            Assert.AreEqual(1,neighbours.Count());
        }
    }

}

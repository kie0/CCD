using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class StarTrek
    {
        public Generation GenerateNextGeneration(Generation genZero)
        {
            var allNeighbours = genZero.GetAllNeighbours();
            var neighbourCount = CountLiving(allNeighbours);
            var cells = genZero.ToList();
            var evolvedCells = EvolveCells(cells, neighbourCount);
            return genZero.Clone(evolvedCells);
        }

        private List<int> CountLiving(List<List<bool>> allNeighbours)
        {
            return allNeighbours.Select(neigbours => neigbours.Count).ToList();
        }

        private List<bool> EvolveCells(List<bool> cells, List<int> neighbourCounts)
        {
            return cells.Zip(neighbourCounts, EvolveCell).ToList();
        }

        private static bool EvolveCell(bool current, int neighbourCount)
        {
            if (!current) return neighbourCount > 2;
            if (neighbourCount > 1 && neighbourCount <4)
                return true;
            return false;
        }
    }
}

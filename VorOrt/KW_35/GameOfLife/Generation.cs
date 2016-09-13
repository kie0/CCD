using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Generation
    {

        private int columns;
        private int rows;
        private bool[][] cells;


        public Generation(int columns, int rows, bool[][] cells)
        {
            this.columns = columns;
            this.rows = rows;
            this.cells = cells;
        }

        public List<bool> ToList()
        {
            var result = new List<bool>();
            for (int i = 0; i < rows; i++)
            {
                var cellRow = cells[i];
                for (int j = 0; j < columns; j++)
                {
                    var b = cellRow[j];
                    result.Add(b);
                }
            }
            return result;
        }

        public List<List<bool>> GetAllNeighbours()
        {
            var result = new List<List<bool>>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result.Add(GetNeighbours(i,j).ToList());
                }
            }
            return result;
        }

        public IEnumerable<bool> GetNeighbours(int row, int column)
        {
            ;
            for (int i = Math.Max(0,row-1); i < Math.Min(rows, row + 1); i++)
            {
                var cellRow = cells[i];
                for (int j = Math.Max(0, column - 1); j < Math.Min(columns, column + 1); j++)
                {
                    if (row != i && column != j)
                        yield return cellRow[j];
                }
            }
        }

        public Generation Clone(List<bool> evolvedCells)
        {
            var result = new Generation(rows, columns, cells);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result.cells[i][j] = evolvedCells[i*3 + j];
                }
            }
            return result;
        }
    }
}

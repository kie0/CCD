using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using ViewCSVFiles.Adapters;

namespace ViewCSVFiles
{
    public class App
    {
        private readonly IConsole console;
        private readonly IIo io;
        private readonly IEnvironment environment;


        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Object"/>-Klasse.
        /// </summary>
        public App(IConsole console, IIo io, IEnvironment environment)
        {
            this.console = console;
            this.io = io;
            this.environment = environment;
        }

        public void Run()
        {
            int pageIndex = 0;
            var pageLength = environment.PageLength;
            var fileName = environment.FileName;
            var  csvInfo = ReadCsvInfo(fileName);
            var maxPageIndex = CalculateMaxPageIndex(csvInfo.RowsCount,pageLength);
            console.GetCommand( command  =>
            {
                pageIndex = UpdatePageIndex(command, pageIndex, maxPageIndex);
                string[] rows = ReadSpecificPage(pageIndex, pageLength, fileName);
                WritePage(csvInfo.Header, rows);
            });
                
        }
        private CsvInfo ReadCsvInfo(string fileName)
        {
            var headerLine= io.ReadCsv(fileName).First();
            var rowsCount = io.ReadCsv(fileName).Count() - 1;
            return new CsvInfo() {Header = headerLine, RowsCount = rowsCount};
        }

        private int CalculateMaxPageIndex(int rowsCount, int pageLength)
        {
            return (rowsCount-1)/pageLength +1;   
        }



        private int UpdatePageIndex(string command, int pageIndex, int maxPageLength)
        {
            command = command.ToLower();
            if (command == "n")
                return pageIndex == maxPageLength ? maxPageLength :pageIndex + 1;
            if (command == "p")
                return pageIndex ==0? 0:pageIndex - 1;

            if (command == "f")
                return 0;
            if (command == "l")
                return maxPageLength;
            throw new NotImplementedException("not implemented command");
        }
        

        private string[] ReadSpecificPage(int pageIndex, int pageLength, string fileName)
        {
            var rows = io.ReadCsv(fileName);
            return ReadSpecificRows(rows, pageIndex, pageLength);
        }

        private string[] ReadSpecificRows(IEnumerable<string> rows, int pageIndex, int pageLength)
        {
            return rows.Skip(pageIndex * pageLength + 1).Take(pageLength).ToArray();
        }

        private void WritePage(string header, string[] rows)
        {
            SplitColumnResult splitResult = SplitInColumn(rows, header);
            int[] columnWidth = CalcColumnWidth(splitResult);
            WriteHeader(splitResult.HeaderCol, columnWidth);
            WriteDataRow(splitResult.DataCol, columnWidth);
            WriteFooter();
        }

        private SplitColumnResult SplitInColumn(string[] rows, string header)
        {
            var result = rows.Select(s => s.Split(new []{';'}, StringSplitOptions.None));
            var headerResult = header.Split(new[] {';'}, StringSplitOptions.None);

            var splitColumnResult = new SplitColumnResult
            {
                DataCol = result,
                HeaderCol = headerResult,
            };
            return splitColumnResult;
        }

        private int[] CalcColumnWidth(SplitColumnResult splitResult)
        {
            var unitedCols = splitResult.DataCol.Union(new[] { splitResult.HeaderCol });
            var result = new int[splitResult.HeaderCol.Length];
            foreach (var unitedCol in unitedCols)
            {
                for (int i = 0; i < unitedCol.Length; i++)
                {
                    result[i] = Math.Max(result[i],unitedCol[i].Length);
                }    
            }
            return result;
        }
        private void WriteHeader(string[] headerCol, int[] columnWidth)
        {
            var header = "";
            var underline = "";
            for (int i = 0; i < columnWidth.Length; i++)
            {
                var width = columnWidth[i];
                var head = headerCol[i].PadRight(width);
                var under = new string('-',width)+"+";
                header = header + $"{head}|";
                underline = underline + under;
            }
            console.WriteLine(header);
            console.WriteLine(underline);
        }
        private void WriteDataRow(IEnumerable<string[]> dataCol, int[] columnWidth)
        {
            foreach (var row in dataCol)
            {
                var line = "";
                for (int i = 0; i < columnWidth.Length; i++)
                {
                    var width = columnWidth[i];
                    var cell = row[i].PadRight(width);
                    line = line + $"{cell}|";
                }
                console.WriteLine(line);
            }
        }

        private void WriteFooter()
        {
            console.WriteLine("N(ext page, P(revious page, F(irst page, L(ast page, eX(it");
        }


    }

    public class CsvInfo
    {
        public string Header { get; set; }
        public int RowsCount { get; set; }
    }
}

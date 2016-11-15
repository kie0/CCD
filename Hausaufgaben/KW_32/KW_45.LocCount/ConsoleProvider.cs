using System;
using KataLoc;

namespace KW_45.LocCount
{
    public class ConsoleProvider : IConsole
    {
        public void WriteOutput(string filename, LocResult locResult)
        {
            Console.WriteLine($"{filename};{locResult.LinesOfCode};{locResult.TotalLines}");
        }
    }
}
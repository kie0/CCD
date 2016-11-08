
using System;
using System.Collections.Generic;

namespace WordCount
{
    public interface IConsole
    {
        string Read();
        void Write(ResultOfCounts counts);
        void Write(IEnumerable<string> index);
    }

    public class Console : IConsole
    {
        public string Read()
        {
            System.Console.Write("Enter Text:");
            var text = System.Console.ReadLine();
            if (text != null) return text.Replace("Enter Text:", String.Empty);
            return String.Empty;
        }

        public void Write(ResultOfCounts counts)
        {
            System.Console.WriteLine($"Number of words: {counts.Count}, unique: {counts.UniqueCount}");
        }

        public void Write(IEnumerable<string> index)
        {
            System.Console.WriteLine("Index:");
            foreach (var entry in index)
            {
                System.Console.WriteLine(entry);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public interface IIo
    {
        string ReadText();
        void WriteText(int countWords);
        string[] ReadStoppedWords();
    }

    public class Io : IIo
    {

        public string ReadText()
        {
            Console.Write("Enter Text:");
            return Console.ReadLine();
        }

        public void WriteText(int countWords)
        {
            Console.WriteLine(countWords);
        }

        public string[] ReadStoppedWords()
        {
            return File.ReadAllLines("stoppedwords.txt");
        }
    }
}

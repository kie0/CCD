using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class FileSystem
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public string[] ReadStoppedWords()
        {
            return File.ReadAllLines("stoppedwords.txt");
        }
    }
}

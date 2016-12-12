using System.Collections.Generic;
using System.IO;

namespace ViewCSVFiles.Adapters
{
    public class IoAdapter:IIo
    {
        public IEnumerable<string> ReadCsv(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}

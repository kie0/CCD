using System.Collections.Generic;

namespace ViewCSVFiles.Adapters
{
    public interface IIo
    {
        IEnumerable<string> ReadCsv(string fileName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KW_45.LocCount
{
    public interface IFileSystem
    {
        void GetFiles(string dir, Action<string> onFilename);
        string ReadContent(string filename);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataLoc;

namespace KW_45.LocCount
{
    public interface IConsole
    {
        void WriteOutput(string filename, LocResult locResult);
    }
}

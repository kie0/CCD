using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewCSVFiles.Adapters;

namespace ViewCSVFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            new App(
                new ConsoleAdapter(), 
                new IoAdapter(), 
                new EnvironmentAdapter()).Run();
        }
    }
}

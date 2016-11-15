using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KW_45.LocCount
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsole console = new ConsoleProvider();
            IFileSystem fileSystem = new FileSystemProvider();
            IEnvironment environment = new EnvironmentProvider();
            var app = new App(console, fileSystem, environment);
            app.Run();
        }
    }
}

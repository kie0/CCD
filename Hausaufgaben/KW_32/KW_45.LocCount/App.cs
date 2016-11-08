using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataLoc;

namespace KW_45.LocCount
{
    public class App
    {
        private readonly IConsole console;
        private readonly IFileSystem fileSystem;
        private readonly IEnvironment environment;

        public App(IConsole console, IFileSystem fileSystem, IEnvironment environment)
        {
            this.console = console;
            this.fileSystem = fileSystem;
            this.environment = environment;
        }

        public void Run()
        {
            var dir = environment.GetDir();
            var loc = new Loc();
            fileSystem.GetFiles(dir,
                filename =>
                {
                    var csSource = fileSystem.ReadContent(filename);
                    var locResult = loc.CountLOC(csSource);
                    console.WriteOutput(filename, locResult);
                }
                    
            );
            
        }
    }
}

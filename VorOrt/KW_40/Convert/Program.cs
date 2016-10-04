using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert
{
    class Program
    {
        static void Main(string[] args)
        {
            var io = new Io();
            var app = new App(io);
            app.Run(args);
        }
    }
}

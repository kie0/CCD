﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {


        static void Main(string[] args)
        {

            var app = new App(new Cli(args), new FileSystem(), new Console());
            app.Run();
        }
    }
}

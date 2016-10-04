using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert
{
    public class App
    {
        private readonly IIo io;

        public App(Io io )
        {
            this.io = io;
        }

        public void Run(params string[] args)
        {
            var zahl = io.Get(args);
            
            RomanConverter.Parse(zahl,
                d =>
                {
                    var romanText = RomanConverter.ToRoman(d);
                    io.Ausgeben(romanText);
                },
                r => io.Ausgeben(RomanConverter.FromRoman(r)));
        }
    }
}

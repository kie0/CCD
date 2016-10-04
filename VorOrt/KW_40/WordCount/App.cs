using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class App
    {
        private IIo io;
        
        public App(IIo io)
        {
            this.io = io;
        }

        public void Run()
        {
            var text = io.ReadText();
            var stoppedWords = io.ReadStoppedWords();

            var counter = new Counter();

            var count = counter.CountWords(text,stoppedWords);
            io.WriteText(count);
        }
    }
}

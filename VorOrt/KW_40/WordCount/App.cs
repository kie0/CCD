using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class App
    {
        private readonly Cli cli;
        private readonly FileSystem fs;
        private readonly Console shell;

        public App(Cli cli, FileSystem fs, Console shell)
        {
            this.cli = cli;
            this.fs = fs;
            this.shell = shell;
        }

        public void Run()
        {
            var text = ReadText();
            var stoppedWords = fs.ReadStoppedWords();

            var counter = new Counter();

            var count = counter.CountWords(text,stoppedWords);
            shell.Write(count);
        }

        private string ReadText()
        {
            string result=null;
            cli.GetFileName(
                path => {
                            result = fs.Read(path);
                },
                () => {
                          result = shell.Read();
                });
            return result;
        }
    }
}

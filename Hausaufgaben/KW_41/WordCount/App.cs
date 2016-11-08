
using System;
using System.Linq;

namespace WordCount
{
    public class App
    {
        private readonly IConsole console;
        private readonly IFileSystem file;
        private readonly ICommandLineInterface cli;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Object"/>-Klasse.
        /// </summary>
        public App(IConsole console, IFileSystem file, ICommandLineInterface cli)
        {
            this.console = console;
            this.file = file;
            this.cli = cli;
        }

        public void Run()
        {
            var text = ReadText();
            var stopwords = file.ReadStopWords();
            var withIndex = ReadIndex();

            var conv = new Counter();
            conv.Count(text, stopwords,withIndex, 
                count => console.Write(count),
                index => console.Write(index));

        }

        private bool ReadIndex()
        {
            return cli.GetIndexOption(Environment.GetCommandLineArgs().Skip(1).ToArray());
        }

        public string ReadText()
        {
            var result = string.Empty;
            cli.Get(Environment.GetCommandLineArgs().Skip(1).ToArray(), 
                s => result = file.Read(s), 
                () => result = console.Read());
            return result;
        }

    }
}

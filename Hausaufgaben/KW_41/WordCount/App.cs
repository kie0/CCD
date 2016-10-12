
using System;

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

            var conv = new Counter();
            var count = conv.Count(text, stopwords);

            console.Write(count);
        }

        public string ReadText()
        {
            var result = string.Empty;
            cli.Get(Environment.GetCommandLineArgs(), 
                s => result = file.Read(s), 
                () => result = console.Read());
            return result;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount.Tests
{
    class CommandLineMock:ICommandLineInterface
    {
        private readonly string fileName;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Object"/>-Klasse.
        /// </summary>
        public CommandLineMock(string fileName)
        {
            this.fileName = fileName;
        }

        public void Get(string[] args, Action<string> onFilename, Action onNoFilename)
        {
            if (string.IsNullOrEmpty(fileName))
                onNoFilename();
            else
                onFilename(fileName);
        }
    }
}

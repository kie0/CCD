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
        private readonly bool withIndex;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Object"/>-Klasse.
        /// </summary>
        public CommandLineMock(string fileName, bool withIndex=false)
        {
            this.fileName = fileName;
            this.withIndex = withIndex;
        }

        public void Get(string[] args, Action<string> onFilename, Action onNoFilename)
        {
            if (string.IsNullOrEmpty(fileName))
                onNoFilename();
            else
                onFilename(fileName);
        }

        public bool GetIndexOption(string[] args)
        {
            return withIndex;
        }
    }
}

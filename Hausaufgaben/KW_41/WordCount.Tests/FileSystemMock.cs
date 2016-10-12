using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount.Tests
{
    public class FileSystemMock:IFileSystem
    {
        private readonly string fileContent;
        private readonly string[] stopWords;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Object"/>-Klasse.
        /// </summary>
        public FileSystemMock(string fileContent, string[] stopWords)
        {
            this.fileContent = fileContent;
            this.stopWords = stopWords;
        }

        public string Read(string fileName)
        {
            return fileContent;
        }

        public string[] ReadStopWords()
        {
            return stopWords; 
        }
    }
}

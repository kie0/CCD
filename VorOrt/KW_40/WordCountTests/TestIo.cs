using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCount;

namespace WordCountTests
{
    public class TestIo:IIo
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Object"/>-Klasse.
        /// </summary>
        public TestIo(string[] stoppedWords, string text)
        {
            this.stoppedWords = stoppedWords;
            this.text = text;
        }

        private string[] stoppedWords;
        private string text;
        private string output;



        public string Output
        {
            get { return output; }
        }

        public string ReadText()
        {
            return text;
        }

        public void WriteText(int countWords)
        {
            output = "" + countWords;
        }

        public string[] ReadStoppedWords()
        {
            return stoppedWords;
        }
    }
}

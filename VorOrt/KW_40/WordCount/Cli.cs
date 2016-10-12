using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class Cli
    {
        private string[] args;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Object"/>-Klasse.
        /// </summary>
        public Cli(string[] args)
        {
            this.args = args;
        }

        public void GetFileName(Action<string> continueFileName, Action continueNoFileName)
        {
            var fileName = args.FirstOrDefault();
            if (!string.IsNullOrEmpty(fileName))
                continueFileName(fileName);
            else
                continueNoFileName();
        }
    }
}

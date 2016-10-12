using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount.Tests
{
    public class ConsoleMock:IConsole
    {
        private readonly string read;
        private ResultOfCounts writeResultOfCounts;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Object"/>-Klasse.
        /// </summary>
        public ConsoleMock(string read)
        {
            this.read = read;
        }

        public string Read()
        {
            return read;
        }

        public void Write(ResultOfCounts counts)
        {
            writeResultOfCounts=counts;
        }

        public ResultOfCounts WriteResultOfCounts => writeResultOfCounts;
    }
}

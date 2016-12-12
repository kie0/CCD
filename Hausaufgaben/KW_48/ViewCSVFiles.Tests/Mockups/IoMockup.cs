using System.Collections.Generic;
using ViewCSVFiles.Adapters;

namespace ViewCSVFiles.Tests.Mockups
{
    public class IoMockup:IIo
    {
        private string[] lines;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Object"/>-Klasse.
        /// </summary>
        public IoMockup(params string[] lines)
        {
            this.lines = lines;
        }

        public IEnumerable<string> ReadCsv(string fileName)
        {
            return lines;
        }
    }
}

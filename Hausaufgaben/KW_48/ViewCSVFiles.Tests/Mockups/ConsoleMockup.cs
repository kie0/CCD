using System;
using System.Collections.Generic;
using ViewCSVFiles.Adapters;

namespace ViewCSVFiles.Tests.Mockups
{
    class ConsoleMockup:IConsole
    {
        private int index;
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Object"/>-Klasse.
        /// </summary>
        public ConsoleMockup(params string[] strings)
        {
            this.Strings = strings;
        }

        public void GetCommand(Action<string> onCommand)
        {
            var result = Strings[index];
            index++;
            if (index >= Strings.Length)
                index = 0;
            onCommand(result);
        }

        public void WriteLine(string line)
        {
            Output.Add(line);
        }

        public List<string> Output { get; } = new List<string>();

        public string[] Strings { get; }
    }
}

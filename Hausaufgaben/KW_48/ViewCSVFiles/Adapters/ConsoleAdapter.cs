using System;

namespace ViewCSVFiles.Adapters
{
    public class ConsoleAdapter:IConsole
    {
        public void GetCommand(Action<string> onCommand)
        {
            var cmd = "f";
            do
            {
                onCommand(cmd);
                cmd = Console.ReadLine();
                cmd = cmd?.ToLower();
            }
            while (cmd != "x");
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}

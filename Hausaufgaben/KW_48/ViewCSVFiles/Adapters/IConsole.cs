using System;

namespace ViewCSVFiles.Adapters
{
    public interface IConsole
    {
        void GetCommand(Action<string> onCommand);
        void WriteLine(string line);
    }
}

using System;

namespace WordCount
{
    public interface ICommandLineInterface
    {
        void Get(string[] args, Action<string> onFilename, Action onNoFilename);
    }

    /// <summary>
    /// Command Line Interface
    /// </summary>
    public class CLI : ICommandLineInterface
    {
        public void Get(string[] args, Action<string> onFilename, Action onNoFilename)
        {
            if (args.Length > 0 )
            {
                onFilename(args[0]);
            }
            else
            {
                onNoFilename();
            }
        }


    }
}

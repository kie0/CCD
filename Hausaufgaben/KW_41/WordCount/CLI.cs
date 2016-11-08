using System;
using System.Linq;

namespace WordCount
{
    public interface ICommandLineInterface
    {
        void Get(string[] args, Action<string> onFilename, Action onNoFilename);
        bool GetIndexOption(string[] args);
    }

    /// <summary>
    /// Command Line Interface
    /// </summary>
    public class CLI : ICommandLineInterface
    {
        public void Get(string[] args, Action<string> onFilename, Action onNoFilename)
        {
            var x = args.Where(a => !a.StartsWith("-")).ToArray();
            if (x.Length > 0)
            {
                onFilename(x[0]);
            }
            else
            {
                onNoFilename();
            }
        }

        public bool GetIndexOption(string[] args)
        {
            return args.Contains("-index", StringComparer.InvariantCultureIgnoreCase);
        }



    }
}

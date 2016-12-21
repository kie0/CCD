using System;

namespace ViewCSVFiles.Adapters
{
    public class EnvironmentAdapter:IEnvironment
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Object"/>-Klasse.
        /// </summary>
        public EnvironmentAdapter()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
                FileName = args[1];
            int pageSizeParsed;
            if (args.Length > 2 && int.TryParse(args[2], out pageSizeParsed))
            {
                PageLength = pageSizeParsed;
            }
            else
            {
                PageLength = 40;
            }
        }

        public string FileName { get; set; }
        public int PageLength { get; }
    }
}

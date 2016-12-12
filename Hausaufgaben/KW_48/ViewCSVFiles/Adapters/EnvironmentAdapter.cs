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
            if (args.Length > 0)
                FileName = args[0];
            int pageSizeParsed;
            if (args.Length > 1 && int.TryParse(args[1], out pageSizeParsed))
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

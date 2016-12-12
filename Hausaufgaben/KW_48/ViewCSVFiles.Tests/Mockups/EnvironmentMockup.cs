using ViewCSVFiles.Adapters;

namespace ViewCSVFiles.Tests.Mockups
{
    public class EnvironmentMockup:IEnvironment
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Object"/>-Klasse.
        /// </summary>
        public EnvironmentMockup(string fileName, int pageSize)
        {
            FileName = fileName;
            PageLength = pageSize;
        }

        public string FileName { get; set; }
        public int PageLength { get; }
    }
}

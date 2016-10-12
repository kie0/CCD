using System.IO;

namespace WordCount
{
    public interface IFileSystem
    {
        string Read(string fileName);
        string[] ReadStopWords();
    }

    public class FileSystem : IFileSystem
    {
        public string Read(string fileName)
        {
            if (File.Exists(fileName))
                return File.ReadAllText(fileName);
            return string.Empty;
        }

        public string[] ReadStopWords()
        {
            if (File.Exists("stopwords.txt"))
                return File.ReadAllLines("stopwords.txt");

            return new[] { "the", "a", "on", "off" };
        }
    }
}

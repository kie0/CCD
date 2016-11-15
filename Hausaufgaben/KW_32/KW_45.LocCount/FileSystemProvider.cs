using System;
using System.IO;

namespace KW_45.LocCount
{
    public class FileSystemProvider : IFileSystem
    {
        public void GetFiles(string dir, Action<string> onFilename)
        {
            foreach (var file in Directory.EnumerateFiles(dir, "*.cs", SearchOption.AllDirectories))
                onFilename(file);
        }

        public string ReadContent(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}
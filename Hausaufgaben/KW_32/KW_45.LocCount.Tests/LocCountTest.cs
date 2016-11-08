using System;
using System.Collections.Generic;
using KataLoc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KW_45.LocCount.Tests
{
    [TestClass]
    public class LocCountTest
    {
        [TestMethod]
        public void TestRun()
        {
            var fileSystemMock = new FileSystemMock();
            var environmentMock = new EnvironmentMock();
            var consoleMock = new ConsoleMock();

            var app = new App(consoleMock, fileSystemMock, environmentMock);
            app.Run();

            foreach (var file in fileSystemMock.Files)
            {
                var result = consoleMock.Results[file];
                Assert.AreEqual(1,result.TotalLines);
                Assert.AreEqual(1,result.LinesOfCode);
            }
        }
    }

    public class EnvironmentMock : IEnvironment
    {
        public string GetDir()
        {
            return "d:\\myproject";
        }
    }

    public class FileSystemMock : IFileSystem
    {
        private List<string> files;

        public FileSystemMock()
        {
            files = new List<string>()
            {
                @"d:\myproject\source\main.cs",
                @"d:\myproject\source\logic.cs",
                @"d:\myproject\source\adapters\db.cs",
                @"d:\myproject\source\adapters\twitter.cs"
            };
        }

        public List<string> Files
        {
            get { return files; }
        }

        public void GetFiles(string dir, Action<string> onFilename)
        {
            files.ForEach(onFilename);
        }

        public string ReadContent(string filename)
        {
            return filename;
        }
    }

    public class ConsoleMock : IConsole
    {
        private Dictionary<string,LocResult>results =new Dictionary<string, LocResult>(StringComparer.InvariantCultureIgnoreCase);
        public void WriteOutput(string filename, LocResult locResult)
        {
            results[filename]=locResult;
        }

        public Dictionary<string, LocResult> Results
        {
            get { return results; }
        }
    }
}

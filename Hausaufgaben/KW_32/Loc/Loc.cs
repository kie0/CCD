using System;
using System.Collections.Generic;
using System.Linq;

namespace KataLoc
{
    public class Loc
    {
        public int CountLOC(string csSource)
        {
            var lines = GetLines(csSource);

            var removedCommentsInLines = RemoveCommentLines(lines);

            var finalLines = RemoveCommentBlocks(removedCommentsInLines);

            return finalLines.Count();
        }

        public IEnumerable<string> GetLines(string source)
        {
            return source.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
        }
        
        public IEnumerable<string> RemoveCommentLines(IEnumerable<string> lines)
        {
            return lines.Select(RemoveCommentInLine).Where(line => !line.StartsWith("//") && !string.IsNullOrWhiteSpace(line));
        }

        public string RemoveCommentInLine(string line)
        {
            var startComment = line.IndexOf("/*", StringComparison.InvariantCultureIgnoreCase);
            var endComment = line.IndexOf("*/", StringComparison.InvariantCultureIgnoreCase);
            if ((startComment < endComment) && (startComment != -1) && (endComment != -1))
                return RemoveCommentInLine(line.Remove(startComment, endComment - startComment + 2));
            return line;
        }

        public IEnumerable<string> RemoveCommentBlocks(IEnumerable<string> linesWithContent)
        {
            var inComment = false;

            foreach (var line in linesWithContent)
            {
                if (inComment)
                {
                    int index = line.IndexOf("*/", StringComparison.InvariantCultureIgnoreCase);
                    if (index >= 0)
                    {
                        if (index + 1 != line.Length - 1) // nicht letzte Zeichen
                            yield return line;
                        inComment = false;
                    }
                }
                else
                {
                    int index = line.IndexOf("/*", StringComparison.InvariantCultureIgnoreCase);
                    if (index >= 0)
                    {
                        if (index > 0) // nicht erstes Zeichen
                            yield return line;
                        inComment = true;
                    }
                    else
                    {
                        yield return line;
                    }
                }
            }
        }
    }
}

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

            var removedCommentsInLines = FilterNonCodeLines(lines);

            var finalLines = BlockComments.RemoveCommentBlocks(removedCommentsInLines);

            return finalLines.Count();  
        }

        public IEnumerable<string> GetLines(string source)
        {
            return source.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
        }
        
        public IEnumerable<string> FilterNonCodeLines(IEnumerable<string> lines)
        {
            lines = RemoveBlockComments(lines);
            lines = FilterSimpleComments(lines);
            return FilterEmptyLines(lines);
        }

        private IEnumerable<string> FilterSimpleComments(IEnumerable<string> lines)
        {
            return lines.Where(line => !line.Trim().StartsWith("//"));
        }

        private IEnumerable<string> RemoveBlockComments(IEnumerable<string> lines)
        {
            return lines.Select(BlockComments.RemoveBlockCommentsInLine);
        }

        private IEnumerable<string> FilterEmptyLines(IEnumerable<string> lines)
        {
            return lines.Where(line => !string.IsNullOrWhiteSpace(line));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataLoc
{
    public class BlockComments
    {
        public static string RemoveBlockCommentsInLine(string line)
        {
            var startComment = line.IndexOf("/*", StringComparison.InvariantCultureIgnoreCase);
            var endComment = line.IndexOf("*/", StringComparison.InvariantCultureIgnoreCase);
            if ((startComment < endComment) && (startComment != -1) && (endComment != -1))
                return RemoveBlockCommentsInLine(line.Remove(startComment, endComment - startComment + 2));
            return line;
        }

        public static IEnumerable<string> RemoveCommentBlocks(IEnumerable<string> linesWithContent)
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

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class Counter
    {
        public ResultOfCounts Count(string text, string[] stopwords)
        {
            var words = SplitWords(text);

            var filtered = Filter(words, stopwords);

            var count = CountAll(filtered);
            var uniqueCount = CountUnique(filtered);

            return new ResultOfCounts(count, uniqueCount); 
        }

        private string[] SplitWords(string text)
        {
            var worte = Regex.Matches(text, @"[a-zA-Z]+");
            return worte.OfType<Match>().Select(w => w.Value).ToArray();
        }

        private string[] Filter(string[] words, string[] stopwords)
        {
            var filtered = words.Where(w => !stopwords.Contains(w));
            return filtered.ToArray();
        }

        private int CountAll(string[] words)
        {
            return words.Count();
        }

        private int CountUnique(string[] words)
        {
            return words.Distinct().Count();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class Counter
    {
        public void Count(string text, string[] stopwords, bool withIndex, 
            Action<ResultOfCounts> continueWithCounts,
            Action<string[]> continueWithIndex)
        {
            var words = SplitWords(text);

            var filtered = Filter(words, stopwords);

            var count = CountAll(filtered);
            var uniqueWords = DistinctList(filtered);
            var uniqueCount = CountAll(uniqueWords);

            continueWithCounts(new ResultOfCounts(count, uniqueCount));

            CreateIndex(withIndex,uniqueWords, continueWithIndex);

        }

        private void CreateIndex(bool withIndex, IEnumerable<string> uniqueWords, 
            Action<string[]> continueWithIndex)
        {
            if (withIndex)
            {
                var index = uniqueWords.OrderBy(s => s,StringComparer.InvariantCultureIgnoreCase).ToArray();
                continueWithIndex(index);
            }
        }

        private static IEnumerable<string> DistinctList(string[] filtered)
        {
            return filtered.Distinct(StringComparer.InvariantCultureIgnoreCase);
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

        private int CountAll(IEnumerable<string> words)
        {
            return words.Count();
        }

    }
}

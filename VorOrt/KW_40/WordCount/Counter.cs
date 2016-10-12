using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class Counter
    {
        public int CountWords(string input, string[] stoppedWords)
        {
            var words = SplitWords(input);
            var filtered = Filter(words, stoppedWords);
            return CountWords(filtered);
        }

        private string[] Filter(IEnumerable<string> words, IEnumerable<string> stoppedWords)
        {
            return words.Where(word => !stoppedWords.Contains(word, StringComparer.InvariantCultureIgnoreCase)).ToArray();
        }

        private static int CountWords(string[] words)
        {
            return words.Length;
        }

        private static string[] SplitWords(string input)
        {
            var words = input.Split(new[] {' ','\n','\r'}, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
    }
}

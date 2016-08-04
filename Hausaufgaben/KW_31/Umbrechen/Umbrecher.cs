using System;
using System.Collections.Generic;

namespace Umbrechen
{
    public class Umbrecher
    {
        public string Umbrechen(string text, int maxZeilenlänge)
        {
            var worte = WorteLesen(text);
            var umbruchText = WorteZusammenfügen(worte, maxZeilenlänge);
            return umbruchText;
        }

        public IEnumerable<string> WorteLesen(string text)
        {
            return text.Split(new[] {" ", "\n"}, StringSplitOptions.RemoveEmptyEntries);
        }

        public IEnumerable<string> WorteNormieren(IEnumerable<string> worte, int maxZeichenlänge)
        {
            List<string> result = new List<string>();
            foreach (var wort in worte)
            {
                if (wort.Length <= maxZeichenlänge) result.Add(wort);
                else result.AddRange(TeileInNormierteWorte(maxZeichenlänge, wort));
            }
            return result;
        }

        private static IEnumerable<string> TeileInNormierteWorte(int maxZeichenlänge, string wort)
        {
            for (int i = 0; i < wort.Length; i += maxZeichenlänge)
                yield return wort.Substring(i, Math.Min(maxZeichenlänge, wort.Length - i));
        }

        public IEnumerable<string> WorteInZeilen(IEnumerable<string> worte, int maxZeichenlänge)
        {
            string zeile = string.Empty;
            foreach (var wort in worte)
            {
                if (zeile == "")
                {
                    zeile += wort;
                }
                else if (zeile.Length + 1 + wort.Length <= maxZeichenlänge)
                {
                    zeile += " " + wort;
                }
                else
                {
                    yield return zeile;
                    zeile = wort;
                }
            }
            if (!string.IsNullOrEmpty(zeile))
                yield return zeile;
        }

        public string ZeilenInText(IEnumerable<string> worte)
        {
            return string.Join("\n", worte);
        }

        public string WorteZusammenfügen(IEnumerable<string> worte, int maxZeichenlänge)
        {
            var normiert = WorteNormieren(worte, maxZeichenlänge);
            var umgebrochen = WorteInZeilen(normiert, maxZeichenlänge);
            return ZeilenInText(umgebrochen);
        }
    }
}

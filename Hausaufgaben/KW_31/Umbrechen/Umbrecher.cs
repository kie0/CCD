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

        public string WorteZusammenfügen(IEnumerable<string> worte, int maxZeichenlänge)
        {
            var normiert = WorteNormieren(worte, maxZeichenlänge);
            var umgebrochen = WorteInZeilen(normiert, maxZeichenlänge);
            return ZeilenInText(umgebrochen);
        }

        public IEnumerable<string> WorteNormieren(IEnumerable<string> worte, int maxZeichenlänge)
        {
            foreach (var wort in worte)
            {
                for (int i = 0; i < wort.Length; i += maxZeichenlänge)
                    yield return wort.Substring(i, Math.Min(maxZeichenlänge, wort.Length - i));
            }
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

        public string ZeilenInText(IEnumerable<string> zeilen)
        {
            return string.Join("\n", zeilen);
        }


    }
}

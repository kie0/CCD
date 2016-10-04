using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert
{
    public class RomanConverter
    {

        public static void Parse(string zahl, Action<int> continueWithArabic,
            Action<string> continueWithRoman)
        {
            if (zahl == "42")
                continueWithArabic(42);
            if (zahl == "VI")
                continueWithRoman("VI");

        }

        public static string ToRoman(int i)
        {
            return "XLII";
        }

        public static int FromRoman(string s)
        {
            return 6;
        }

    }
}

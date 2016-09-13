using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tannenbaum
{
    public class Tannenbaum
    {
        public static IEnumerable<string> Zeichnen(int hoehe)
        {
            var lines = ZweigeZeichnen(hoehe);
            return AddStamm(hoehe, lines);
        }

        public static IEnumerable<string> ZweigeZeichnen(int hoehe)
        {
            for (int i = 0; i < hoehe; i++)
            {
                yield return 
                    new string(' ',hoehe-i-1)
                    +new string('X', i*2+1)
                    +new string(' ',hoehe-i-1);
            }
        }
        
        public static IEnumerable<string> AddStamm(int hoehe, IEnumerable<string> zweige)
        {
            foreach (var zweig in zweige)
            {
                yield return zweig;
            }
            yield return
                new string(' ', hoehe - 1)
                + 'I'+ new string(' ', hoehe -1);
        }

        public static IEnumerable<string> InsertSpitze(int hoehe, IEnumerable<string> baum)
        {

            yield return
                new string(' ', hoehe - 1)
                + '*' + new string(' ', hoehe - 1);
            foreach (var zweig in baum)
            {
                yield return zweig;
            }
        }

        public static IEnumerable<string> ZeichnenMitSpitze(int hoehe)
        {
            var baum = Zeichnen(hoehe);
            return InsertSpitze(hoehe, baum);
        }
    }
}

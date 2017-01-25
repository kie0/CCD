using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCD.Nback.ViewModels;

namespace CCD.Nback
{
    public class ProtokollAdapter : IProtokollAdapter
    {
        public void Write(Test test)
        {
            //Proband = Peter Müller
            //Reizdauer = 500
            //N = 3 Start = 2013 - 05 - 16T18: 34:23
            //Reize =     TLHCHSCCQLCKLH...
            //Antworten = NNNNJNJNNNJNJJ...
            File.AppendAllLines("Protokoll.log", new string[]
                    {
                        $"Proband = {test.Parameter.Proband}",
                        $"Reizdauer = {test.Parameter.Reizdauer}",
                        $"N = {test.Parameter.Nummer} Start = {test.StartDate.ToString("s")}",
                        $"Reize = {new string(test.ReizFolge)}",
                        $"Antworten = {AntwortenFormatieren(test)}",

                    }
                );
        }

        private static string AntwortenFormatieren(Test test)
        {
            return new string(test.ReaktionsFolge.Take(test.Index).Select(reaktion => reaktion == Reaktion.WiederholungErkannt ? 'J' : 'N').ToArray());
        }
    }
}

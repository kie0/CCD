using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD.Nback
{
    public class ReizAdapter:IReizAdapter
    {
        public string ReizErstellen(Parameter parameter)
        {
            //todo: Ausgefuxte Technik für die Erstellung einer Reizfolge
            string reizend = "AAAAAAAAAAAAAAATLHCHSCCQLCKLHTLHCHSCCQLCKLHTLHCHSCCQLCKLHTLHCHSCCQLCKLH";
            var reizTeil = reizend.Substring(0, parameter.ReizeAnzahl);
            return reizTeil;
        }
    }
}

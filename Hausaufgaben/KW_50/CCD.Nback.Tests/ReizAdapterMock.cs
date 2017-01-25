using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD.Nback.Tests
{
    public class ReizAdapterMock:IReizAdapter
    {
        public string ReizErstellen(Parameter parameter)
        {
            return Reiz;
        }

        public string Reiz { get; set; }
    }
}

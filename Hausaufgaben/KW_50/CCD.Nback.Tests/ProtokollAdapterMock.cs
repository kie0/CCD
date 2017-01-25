using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD.Nback.Tests
{
    public class ProtokollAdapterMock:IProtokollAdapter
    {
        private Test result;

        public void Write(Test test)
        {
            result = test;
        }

        public Test Result => result;
    }
}

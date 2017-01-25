using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD.Nback
{
    public interface IProtokollAdapter
    {
        void Write(Test test);
    }
}

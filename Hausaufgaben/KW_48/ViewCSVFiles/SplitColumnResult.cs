using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewCSVFiles
{
    public class SplitColumnResult
    {
        public string[] HeaderCol { get; set; }

        public IEnumerable<string[]> DataCol { get; set; }
    }
}

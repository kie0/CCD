using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class Console
    {
        public string Read()
        {
            return System.Console.ReadLine();
        }

        public void Write(int count)
        {
            System.Console.WriteLine(count);
        }
    }
}

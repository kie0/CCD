using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert
{
    public interface IIo
    {
        string Get(string[] args);
        void Ausgeben(int arabic);
        void Ausgeben(string romanText);
    }

    public class Io : IIo
    {
        public string Get(string[] args)
        {
            return args[0];
        }

        public void Ausgeben(int arabic)
        {
            Console.WriteLine(arabic);
        }
        public void Ausgeben(string romanText)
        {
            Console.WriteLine(romanText);
        }
    }
}

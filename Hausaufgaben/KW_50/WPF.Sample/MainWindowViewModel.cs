using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Sample
{
    public class MainWindowViewModel
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}

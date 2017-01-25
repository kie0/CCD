using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CCD.Nback.Views
{
    /// <summary>
    /// Interaction logic for MainDialog.xaml
    /// </summary>
    public partial class MainDialog : Window, IUiAdapter
    {
        public MainDialog()
        {
            InitializeComponent();
        }

        public void SetDataContext(object neuerContext)
        {
            //DataContext = neuerContext;
            Dispatcher.Invoke(() => DataContext = neuerContext);
        }
    }
}

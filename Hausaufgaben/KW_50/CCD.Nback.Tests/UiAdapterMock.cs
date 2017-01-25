using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD.Nback.Tests
{
    public class UiAdapterMock:IUiAdapter
    {
        private object dataContext;
        public void SetDataContext(object neuerContext)
        {
            dataContext = neuerContext;
        }
        public T Get<T>()
        {
            return (T) dataContext;
        }
    }
}

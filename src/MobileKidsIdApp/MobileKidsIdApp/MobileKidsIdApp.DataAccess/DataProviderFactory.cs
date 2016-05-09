using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess
{
    public class DataProviderFactory
    {
        public IDataProvider GetDataProvider()
        {
            return new LocalStorage.DataProvider();
        }
    }
}

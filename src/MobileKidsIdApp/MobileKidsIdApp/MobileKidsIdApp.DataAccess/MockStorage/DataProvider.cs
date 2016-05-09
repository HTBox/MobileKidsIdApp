using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess.MockStorage
{
    public class DataProvider : IDataProvider
    {
        public IApplicationDataProvider GetApplicationDataProvider()
        {
            return new ApplicationDataProvider();
        }

        public IFamilyProvider GetFamilyProvider()
        {
            return new FamilyProvider();
        }
    }
}

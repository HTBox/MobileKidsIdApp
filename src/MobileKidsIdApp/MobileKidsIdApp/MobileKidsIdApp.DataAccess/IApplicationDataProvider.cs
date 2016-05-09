using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess
{
    public interface IApplicationDataProvider
    {
        DataModels.ApplicationData Get();
        DataModels.ApplicationData Save(DataModels.ApplicationData data);
    }
}

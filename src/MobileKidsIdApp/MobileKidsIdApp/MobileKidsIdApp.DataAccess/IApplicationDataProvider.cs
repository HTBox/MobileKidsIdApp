using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess
{
    public interface IApplicationDataProvider
    {
        Task<DataModels.ApplicationData> Get();
        Task Save(DataModels.ApplicationData data);
    }
}

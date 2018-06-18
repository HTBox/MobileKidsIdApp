using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess
{
    public interface IFamilyProvider
    {
        Task<DataModels.Family> Get();
        Task Save(DataModels.Family data);
    }
}

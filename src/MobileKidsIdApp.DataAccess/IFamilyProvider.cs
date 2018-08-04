using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess
{
    public interface IFamilyProvider
    {
        bool DataExists();
        Task<bool> VerifyPasswordAsync(string password);
        Task<DataModels.Family> GetAsync();
        Task SaveAsync(DataModels.Family data);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess
{
    public interface IFamilyProvider
    {
        DataModels.Family Get();
        void Save(DataModels.Family data);
    }
}

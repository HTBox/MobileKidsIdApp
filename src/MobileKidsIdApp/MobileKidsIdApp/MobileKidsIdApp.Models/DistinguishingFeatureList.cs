using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class DistinguishingFeatureList : BusinessListBase<DistinguishingFeatureList, DistinguishingFeature>
    {
        private void Child_Fetch(List<DataAccess.DataModels.DistinguishingFeature> list)
        {
            foreach (var item in list)
                Add(DataPortal.FetchChild<DistinguishingFeature>(item));
        }
    }
}

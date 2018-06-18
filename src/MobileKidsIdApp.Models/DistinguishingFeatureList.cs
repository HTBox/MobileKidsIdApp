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
        protected override DistinguishingFeature AddNewCore()
        {
            var nextId = 0;
            var maxId = this.OrderByDescending(df => df.Id).FirstOrDefault();
            if (maxId != null)
                nextId = maxId.Id + 1;

            var result = new DistinguishingFeature { Id = nextId };
            Add(result);
            return result;
        }

        private void Child_Fetch(List<DataAccess.DataModels.DistinguishingFeature> list)
        {
            foreach (var item in list)
                Add(DataPortal.FetchChild<DistinguishingFeature>(item));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.BaseTypes
{
    [Serializable]
    public class BusinessBase<T> : Csla.BusinessBase<T> 
        where T: BusinessBase<T>
    {
        public override bool IsSelfDirty
        {
            get { return true; }
        }
    }
}

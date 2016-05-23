using Csla.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class AppPrincipal : CslaPrincipal
    {
        public AppPrincipal(AppIdentity identity)
            : base(identity)
        { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Model
{
    public class ApplicationData
    {
        public ApplicationData()
        {
            PermittedLoginIdentities = Enumerable.Empty<UserIdentity>();
        }

        public UserApplicationProfile UserApplicationProfile { get; set; }
        public IEnumerable<UserIdentity> PermittedLoginIdentities { get; set; }   
    }
}

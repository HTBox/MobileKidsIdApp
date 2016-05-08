using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.DataModels
{
    public class ApplicationData
    {
        public ApplicationData()
        {
            PermittedLoginIdentities = new List<UserIdentity>();
        }

        public UserApplicationProfile UserApplicationProfile { get; set; }
        public List<UserIdentity> PermittedLoginIdentities { get; set; }   
    }
}

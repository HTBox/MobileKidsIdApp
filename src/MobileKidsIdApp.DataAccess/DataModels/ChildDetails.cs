using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess.DataModels
{
    public class ChildDetails
    {
        public string GivenName { get; set; }
        public string NickName { get; set; }
        public string AdditonalName { get; set; }
        public string FamilyName { get; set; }
        public DateTime Birthday { get; set; }
        public string ContactId { get; set; }
        public string ContactNameManual { get; set; }
        public string ContactPhoneManual { get; set; }
    }
}

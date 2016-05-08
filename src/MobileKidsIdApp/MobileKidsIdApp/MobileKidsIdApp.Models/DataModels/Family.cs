using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.DataModels
{
    public class Family
    {
        public Family()
        {
            Children = new List<Child>();
        }
        public List<Child> Children { get; set; }
    }
}

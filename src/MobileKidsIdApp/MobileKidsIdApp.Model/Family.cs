using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Model
{
    public class Family
    {
        public Family()
        {
            Children = Enumerable.Empty<Child>();
        }
        public IEnumerable<Child> Children { get; set; }
    }
}

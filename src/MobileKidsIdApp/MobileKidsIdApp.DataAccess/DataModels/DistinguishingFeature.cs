using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess.DataModels
{
    public class DistinguishingFeature
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public FileReference FileReference { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess.DataModels
{
    public class FileReference
    {
        public string Id
        {
            get;set;
        }

        public string ResourceType
        {
            get; set;
        }

        public string Description { get; set; }
        public string FileName { get; set; }

    }
}

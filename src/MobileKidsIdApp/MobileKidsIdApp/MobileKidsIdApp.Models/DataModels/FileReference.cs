using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.DataModels
{
    public class FileReference : IResourceReference
    {
        public string Id
        {
            get;set;
        }

        public string ResourceType
        {
            get; set;
        }

        string Description { get; set; }
        string FileName { get; set; }

    }
}

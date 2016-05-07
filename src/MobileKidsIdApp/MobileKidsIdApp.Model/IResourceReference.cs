using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Model
{
    /// <summary>
    /// Describes a reference to a file, contact, or foreign entity outside the context of this application.
    /// </summary>
    public interface IResourceReference
    {
        string Id { get; set; }
        string ResourceType { get; set; }
    }
}

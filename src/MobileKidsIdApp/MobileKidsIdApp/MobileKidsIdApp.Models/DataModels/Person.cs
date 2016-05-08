using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.DataModels
{
    public class Person 
    {
        public string Id { get; set; }
        public IContactReference ContactReference { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.GivingToCustomer.Core.Domain
{
    public class Preference
        :BaseEntity
    {
        public Preference()
        {
        }
        
        public Preference(Preference other)
        {
            Id = other.Id;
            Name = other.Name;
        }
        public string Name { get; set; }
    }
}

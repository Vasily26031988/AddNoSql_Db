using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.GivingToCustomer.WebHost.Models
{
    public class RoleItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}

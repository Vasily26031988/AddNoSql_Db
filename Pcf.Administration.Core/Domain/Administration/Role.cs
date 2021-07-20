using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.Administration.Core.Domain.Administration
{
    public class Role
        : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}

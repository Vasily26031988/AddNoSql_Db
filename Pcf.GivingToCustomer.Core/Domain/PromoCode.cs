using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.GivingToCustomer.Core.Domain
{
    public class PromoCode
        : BaseEntity
    {
        public PromoCode()
        {
        }
        
        public PromoCode(PromoCode other, bool clearCustomers)
        {
            Id = other.Id;
            Code = other.Code;
            ServiceInfo = other.ServiceInfo;
            BeginDate = other.BeginDate;
            EndDate = other.EndDate;
            PartnerId = other.PartnerId;
            Preference = other.Preference;
            if (!clearCustomers)
            {
                Customers = other.Customers?
                    .Select(x => new Customer(x, false))
                    .ToList();
            }
        }
        
        public string Code { get; set; }

        public string ServiceInfo { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid PartnerId { get; set; }
        
        public Preference Preference { get; set; }

       public ICollection<Customer> Customers { get; set; }
    }
}

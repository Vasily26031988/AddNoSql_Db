using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.GivingToCustomer.Core.Domain
{
    public class Customer
        :BaseEntity
    {
        public Customer()
        {
        }

        public Customer(Customer other, bool clearPromoCodes)
        {
            Id = other.Id;
            FirstName = other.FirstName;
            LastName = other.LastName;
            Email = other.Email;
            Preferences = other.Preferences?
                .Select(x => new Preference(x))
                .ToList();
            if (!clearPromoCodes)
            {
                PromoCodes = other.PromoCodes?
                    .Select(x => new PromoCode(x, false))
                    .ToList();
            }
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; set; }

        public virtual ICollection<Preference> Preferences { get; set; }
        
        public virtual ICollection<PromoCode> PromoCodes { get; set; }
    }
}

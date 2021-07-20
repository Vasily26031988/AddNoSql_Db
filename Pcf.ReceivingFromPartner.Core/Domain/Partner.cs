using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.ReceivingFromPartner.Core.Domain
{
    public class Partner
        : BaseEntity
    {
        public string Name { get; set; }

        public int NumberIssuedPromoCodes  { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<PartnerPromoCodeLimit> PartnerLimits { get; set; }
        
        public virtual ICollection<PromoCode> PromoCodes { get; set; }
    }
}

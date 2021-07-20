using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pcf.ReceivingFromPartner.Core.Domain;

namespace Pcf.ReceivingFromPartner.Core.Abstractions.Gateways
{
    public interface IGivingPromoCodeToCustomerGateway
    {
        Task GivePromoCodeToCustomer(PromoCode promoCode);
    }
}

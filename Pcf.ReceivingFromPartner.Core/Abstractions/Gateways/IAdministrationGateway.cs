using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.ReceivingFromPartner.Core.Abstractions.Gateways
{
    public interface IAdministrationGateway
    {
        Task NotifyAdminAboutPartnerManagerPromoCode(Guid partnerManagerId);
    }
}

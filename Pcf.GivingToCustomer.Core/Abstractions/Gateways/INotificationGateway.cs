using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Pcf.GivingToCustomer.Core.Domain;

namespace Pcf.GivingToCustomer.Core.Abstractions.Gateways
{
    public interface INotificationGateway
    {
        Task SendNotificationToPartnerAsync(Guid partnerId, string message);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pcf.GivingToCustomer.Core.Abstractions.Gateways;

namespace Pcf.GivingToCustomer.IntegrationTests.Fakes
{
    public class FakeNotificationGateway
        : INotificationGateway
    {
        public Task SendNotificationToPartnerAsync(Guid partnerId, string message)
        {
            //Вместо реальноге сервиса будет вызван этот, который всегда будет работать
            return Task.CompletedTask;
        }
    }
}

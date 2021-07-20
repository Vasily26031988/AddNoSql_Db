﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pcf.GivingToCustomer.Core.Abstractions.Gateways;

namespace Pcf.GivingToCustomer.Integration
{
    public class NotificationGateway
        : INotificationGateway
    {
        public Task SendNotificationToPartnerAsync(Guid partnerId, string message)
        {
            //Код, который вызывает сервис отправки уведомлений партнеру
            
            return Task.CompletedTask;
        }
    }
}

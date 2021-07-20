using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pcf.GivingToCustomer.Core.Abstractions.Gateways;
using Pcf.GivingToCustomer.DataAccess;
using Pcf.GivingToCustomer.Integration;
using Pcf.GivingToCustomer.IntegrationTests.Data;
using Pcf.GivingToCustomer.IntegrationTests.Fakes;

namespace Pcf.GivingToCustomer.IntegrationTests
{
    public class TestWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup: class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<INotificationGateway, FakeNotificationGateway>();
            });
        }
    }
}

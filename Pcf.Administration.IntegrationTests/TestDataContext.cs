using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pcf.Administration.DataAccess;

namespace Pcf.Administration.IntegrationTests
{
    public class TestDataContext
        : DataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=PromocodeFactoryAdministrationDb.sqlite");
        }
    }
}

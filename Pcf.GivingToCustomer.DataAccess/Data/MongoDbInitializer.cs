using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Pcf.GivingToCustomer.Core.Domain;

namespace Pcf.GivingToCustomer.DataAccess.Data
{
    public class MongoDbInitializer : IDbInitializer
    {
        private readonly IMongoCollection<Preference> _preferenceCollection;
        private readonly IMongoCollection<Customer> _customerCollection;
        private readonly IMongoCollection<PromoCode> _promoCodeCollection;

        public MongoDbInitializer(IMongoCollection<Preference> preferenceCollection,
            IMongoCollection<Customer> customerCollection,
            IMongoCollection<PromoCode> promoCodeCollection)
        {
            _preferenceCollection = preferenceCollection;
            _customerCollection = customerCollection;
            _promoCodeCollection = promoCodeCollection;
        }


        public void InitializeDb()
        {
            _promoCodeCollection.DeleteMany(x => true);
            _customerCollection.DeleteMany(x => true);
            _preferenceCollection.DeleteMany(x => true);

            _preferenceCollection.InsertMany(FakeDataFactory.Preferences);
            _customerCollection.InsertMany(FakeDataFactory.Customers);
        }
    }
}

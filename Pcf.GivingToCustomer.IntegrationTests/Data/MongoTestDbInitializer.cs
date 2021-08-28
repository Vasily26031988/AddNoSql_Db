using Microsoft.AspNetCore.Authentication;
using MongoDB.Driver;
using Pcf.GivingToCustomer.Core.Domain;
using Pcf.GivingToCustomer.DataAccess.Data;

namespace Pcf.GivingToCustomer.IntegrationTests.Data
{
    public class MongoTestDbInitializer : IDbInitializer
    {
        private readonly IMongoCollection<Preference> _preferenceCollection;
        private readonly IMongoCollection<Customer> _customerCollection;
        private readonly IMongoCollection<PromoCode> _promoCodeCollection;

        public MongoTestDbInitializer(
            IMongoCollection<Preference> preferenceCollection,
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
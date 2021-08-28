using System;
using MongoDB.Driver;
using Pcf.GivingToCustomer.Core.Domain;
using Pcf.GivingToCustomer.IntegrationTests.Data;

namespace Pcf.GivingToCustomer.IntegrationTests
{
    public class MongoDatabaseFixture : IDisposable
    {
        private readonly MongoTestDbInitializer _testDbInitializer;

        public MongoDatabaseFixture()
        {
            MongoClient = new MongoClient("mongodb://mongoadmin:docker@localhost");
            MongoDatabase = MongoClient.GetDatabase("test");
            PreferenceCollection = MongoDatabase.GetCollection<Preference>("preferences");
            CustomerCollection = MongoDatabase.GetCollection<Customer>("customers");
            PromoCodeCollection = MongoDatabase.GetCollection<PromoCode>("promocodes");
            MongoSession = MongoClient.StartSession();

            _testDbInitializer = new MongoTestDbInitializer(
                PreferenceCollection, CustomerCollection, PromoCodeCollection);
            _testDbInitializer.InitializeDb();
        }

        public void Dispose()
        {
            MongoSession.Dispose();
        }
        
        public IMongoClient MongoClient { get; private set; }
        public IMongoDatabase MongoDatabase { get; private set; }
        public IMongoCollection<Preference> PreferenceCollection { get; private set; }
        public IMongoCollection<Customer> CustomerCollection { get; private set; }
        public IMongoCollection<PromoCode> PromoCodeCollection { get; private set; }
        public IClientSessionHandle MongoSession { get; private set; }
    }
}
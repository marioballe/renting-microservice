using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace RentingMicroservice.InfraestructureTests
{
    [TestFixture]
    public class InfrastructureTests
    {
        private readonly string _connectionString = "mongodb://localhost:27017";
        private MongoClient _client;
        private IMongoDatabase _database;

        [SetUp]
        public void Setup()
        {
            _client = new MongoClient(_connectionString);
            _database = _client.GetDatabase("Renting");
        }

        [Test]
        public void CanConnectAndWriteToDatabase()
        {
            var collection = _database.GetCollection<BsonDocument>("Vehicles");
            var document = new BsonDocument
            {
                { "LicensePlateNumber", "B-2814-TP" },
                { "Model", "Cupra Formentor" },
                { "Year", 2022 }
            };
            collection.InsertOne(document);

            var insertedDocument = collection.Find(new BsonDocument("LicensePlateNumber", "B-2814-TP")).FirstOrDefault();
            Assert.IsNotNull(insertedDocument);

            var deleteFilter = Builders<BsonDocument>.Filter.Eq("LicensePlateNumber", "B-2814-TP");
            collection.DeleteOne(deleteFilter);
        }
    }
}



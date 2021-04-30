using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Tests.DbsConfiguration
{
    class MongoDbConfigurator
    {
        private MongoClient _dbClient;
        public MongoDbConfigurator()
        {
            _dbClient = new MongoClient();
        }
        public void SetUpDb()
        {
            var db = _dbClient.GetDatabase("mongodbTests_1");
            var collectionName = "animal";

            // db.CreateCollection(collectionName);
            Insert();
        }

        public void Insert()
        {
            var db = _dbClient.GetDatabase("mongodbTests_1");
            var collectionName = "animal";
            var collection = db.GetCollection<BsonDocument>(collectionName);

            var listToInsert = new List<BsonDocument>() { //Changed BsonArray to List<BsonDocument>
                new BsonDocument
                {
                    {"guid", "9264f435-d1c7-4f1c-8b84-cf4bdb935641"},
                    {"aid", "1"},
                    {"age", 5 },
                    {"name", "Maffin" }
                },
                new BsonDocument
                {
                    {"guid", "e8d706f8-92be-429c-89cc-91973fca7a95"},
                    {"aid", "2"},
                    {"age", 6 },
                    {"name", "Woody" }
                },
                new BsonDocument
                {
                    {"guid", "f443f95a-3d8f-4786-b3e6-0db8b790f7e6"},
                    {"aid", "3"},
                    {"age", 8 },
                    {"name", "Doggy" }
                }
            };
            collection.InsertMany(listToInsert);
        }
        public void TearDownDb()
        {
            var db = _dbClient.GetDatabase("mongodbTests_1");
            var collectionName = "animal";
            var collection = db.GetCollection<BsonDocument>(collectionName);
            var emptyFilter = Builders<BsonDocument>.Filter.Empty;

            collection.DeleteMany(emptyFilter);
        }
    }
}

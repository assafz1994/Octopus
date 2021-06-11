using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Tests.DbsConfiguration
{
    class MongoDbConfigurator
    {
        private readonly MongoClient _dbClient;

        public MongoDbConfigurator()
        {
            _dbClient = new MongoClient();
        }
        private readonly string[] _collectionsBuyers =
        {
            "buyermongoneo_table",
            "buyermongomongo_table",
        };
        private readonly string[] _collectionsSellers =
        {
            "sellermongosql_table",
            "sellermongomongo_table"
        };
        private readonly string[] _collectionsOthers =
        {
            "animal_table"
        };



        public void SetUpDb()
        {
            var dbName = "mongodbtests_1";
            var db = _dbClient.GetDatabase(dbName);
            foreach (var collectionName in _collectionsBuyers.Concat(_collectionsSellers).Concat(_collectionsOthers))
            {
                bool collectionExists = db.ListCollectionNames().ToList().Contains(collectionName);
                if (collectionExists)
                {
                    db.DropCollection(collectionName);
                }

                db.CreateCollection(collectionName);
            }
        }

        public void SetUpTestOfAnimals()
        {
            var db = _dbClient.GetDatabase("mongodbtests_1");
            var collectionName = "animal_table";
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

        public void SetUpTestOfRelations()
        {
            var db = _dbClient.GetDatabase("mongodbtests_1");

            foreach (var collectionName in _collectionsSellers)
            {
                var collection = db.GetCollection<BsonDocument>(collectionName);
                var listToInsert = new List<BsonDocument>();
                listToInsert.Add(new BsonDocument
                {
                    {"guid", "00000000-0000-0000-0000-000000000021"},
                    {"name", "seller1"},
                    {"favoriteBuyer", "00000000-0000-0000-0000-000000000011"},
                    {"favoriteBuyerMany", BsonNull.Value}
                });

                listToInsert.Add(new BsonDocument
                {
                    {"guid", "00000000-0000-0000-0000-000000000022"},
                    {"name", "seller2"},
                    {"favoriteBuyer", BsonNull.Value},
                    {"favoriteBuyerMany", BsonNull.Value}
                });

                listToInsert.Add(new BsonDocument
                {
                    {"guid","00000000-0000-0000-0000-000000000023"},
                    {"name", "seller3"},
                    {"favoriteBuyer", BsonNull.Value},
                    {"favoriteBuyerMany", new BsonArray()
                    {
                        "00000000-0000-0000-0000-000000000011",
                        "00000000-0000-0000-0000-000000000013"
                    }}
                });

                collection.InsertMany(listToInsert);
            }

            foreach (var collectionName in _collectionsBuyers)
            {
                var collection = db.GetCollection<BsonDocument>(collectionName);
                var listToInsert = new List<BsonDocument>();

                listToInsert.Add(new BsonDocument
                {
                    {"guid","00000000-0000-0000-0000-000000000011"},
                    {"name", "buyer1"},
                    {"buyFrom", "00000000-0000-0000-0000-000000000021"},
                    {"buyFromMany", new BsonArray()
                    {
                        "00000000-0000-0000-0000-000000000021",
                        "00000000-0000-0000-0000-000000000022"
                    }},
                    {"favoriteSeller", BsonNull.Value},
                    {"favoriteSellerMany", BsonNull.Value}
                });

                listToInsert.Add(new BsonDocument
                {
                    {"guid", "00000000-0000-0000-0000-000000000012"},
                    {"name", "buyer2"},
                    {"buyFrom", BsonNull.Value},
                    {"buyFromMany", BsonNull.Value},
                    {"favoriteSeller", BsonNull.Value},
                    {"favoriteSellerMany", BsonNull.Value}
                });

                listToInsert.Add(new BsonDocument
                {
                    {"guid", "00000000-0000-0000-0000-000000000013"},
                    {"name", "buyer3"},
                    {"buyFrom", BsonNull.Value},
                    {"buyFromMany", BsonNull.Value},
                    {"favoriteSeller", "00000000-0000-0000-0000-000000000023"},
                    {"favoriteSellerMany", new BsonArray
                    {
                        "00000000-0000-0000-0000-000000000022",
                        "00000000-0000-0000-0000-000000000023"
                    }}
                });

                collection.InsertMany(listToInsert);
            }
        }

        public void TearDownDb()
        {
            var db = _dbClient.GetDatabase("mongodbtests_1");
            foreach (var collectionName in _collectionsBuyers.Concat(_collectionsSellers).Concat(_collectionsOthers))
            {
                db.DropCollection(collectionName);
            }
        }

        public void InitPerformanceTests()
        {
            const int numOfRows = DbsConfigurator.NumOfRows;
            var db = _dbClient.GetDatabase("mongodbtests_1");
            foreach (var collectionName in _collectionsSellers)
            {
                var collection = db.GetCollection<BsonDocument>(collectionName);
                var listToInsert = new List<BsonDocument>();
                
                for (var i = 0; i < numOfRows; i++)
                {
                    var guid = $"10000000-0000-0000-0000-000000{i:D6}";
                    var name = $"seller{i}";
                    listToInsert.Add(new BsonDocument
                {
                    {"guid", guid},
                    {"name", name},
                });
                }
                collection.InsertMany(listToInsert);
            }

            foreach (var collectionName in _collectionsBuyers)
            {
                var collection = db.GetCollection<BsonDocument>(collectionName);
                var listToInsert = new List<BsonDocument>();

                for (var i = 0; i < numOfRows; i++)
                {
                    var guid = $"00000000-0000-0000-0000-000000{i:D6}";
                    var name = $"buyer{i}";
                    var seller = $"10000000-0000-0000-0000-000000{i:D6}";
                    listToInsert.Add(new BsonDocument
                    {
                        {"guid", guid},
                        {"name", name},
                        {"buyFrom",seller}
                    });
                }
                collection.InsertMany(listToInsert);
            }
        }
    }
}

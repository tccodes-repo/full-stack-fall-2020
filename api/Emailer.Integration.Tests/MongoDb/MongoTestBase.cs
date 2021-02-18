using NUnit.Framework;
using MongoDB.Driver;
using System;
namespace Emailer.MongoDb {

    public class MongoTestBase {

        public IMongoDatabase Db { get; set;}

        [SetUp] 
        public void SetUp() {
            var dbName = "testdb_"+DateTime.Now.ToFileTime();
            var mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
            Db = mongoClient.GetDatabase(dbName);
        }
                

    }

}
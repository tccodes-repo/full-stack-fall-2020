using NUnit.Framework;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Emailer.MongoDb {

    public class MongoTestBase {

        public IMongoDatabase Db { get; set;}

        public MongoClient MongoClient { get; set;}

        public string TestDbName { get; set;}

        [SetUp] 
        public async Task SetUp() {
            MongoClient = new MongoClient("mongodb://127.0.0.1:27017");
            var dbNames = await MongoClient.ListDatabaseNamesAsync();

            var testDbNames = dbNames.ToList().Where(name => name.StartsWith("testdb_"));
            foreach(var tdb in testDbNames) {
                MongoClient.DropDatabase(tdb);
            }
            
            TestDbName = "testdb_"+DateTime.Now.ToFileTime();
            Db = MongoClient.GetDatabase(TestDbName);
        }
                     

    }

}
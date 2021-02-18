using NUnit.Framework;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;
using MongoDB;
using FluentAssertions;

namespace Emailer.MongoDb {

    [TestFixture]
    public class MongoDbRepositoryTests : MongoTestBase {

        [Test]
        public async Task Calling_AddAsync_Inserts_A_Document_Into_The_Collection() {

            var sut = new MongoRepository<Customer>(Db);
            var col = Db.GetCollection<Customer>("Customers");
            var stubCustomer = new Customer {
                FirstName = "John",
                LastName = "Doe"
            };

            (await col.CountDocumentsAsync(Builders<Customer>.Filter.Empty)).Should().Be(0);
            
            await sut.AddAsync(stubCustomer);

            (await col.CountDocumentsAsync(Builders<Customer>.Filter.Empty)).Should().Be(1);

            var actualCustomer = await col.Find(x => x.FirstName == "John").FirstAsync();

            actualCustomer.Should().BeEquivalentTo(stubCustomer);

        }      

    }


}
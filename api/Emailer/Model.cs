using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Emailer
{
    public class Model
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
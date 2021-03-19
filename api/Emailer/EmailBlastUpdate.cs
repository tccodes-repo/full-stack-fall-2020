using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Emailer {

    public class EmailBlastUpdate {

        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;} = "";

        public string EmailBlastId { get; set;}  = "";
    }
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Emailer
{
    public class EmailBlast : Model
    {
        public string? Customer { get; set; }
        
        public string? Template { get; set; }

        public string Status { get; set; } = "Pending";
    }
}
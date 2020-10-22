using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Emailer.Templates
{
    public class Template : Model
    {
        public string? Name { get; set; }
        
        public string? Body { get; set; }
    }
}
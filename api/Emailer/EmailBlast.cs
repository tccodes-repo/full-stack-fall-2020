using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Emailer
{
    public class EmailBlast : Model
    {
        public string? Customer { get; set; }
        
        public string? Template { get; set; }

        public string Status { get; set; } = "Pending";

        public int EmailsDelivered { get; set; } = 0;

        public string Schedule { get; set; } = "* * * ? * * 2100";
        
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        
        public DateTime StatusChangedOn { get; set; } = DateTime.Now;
    }
}
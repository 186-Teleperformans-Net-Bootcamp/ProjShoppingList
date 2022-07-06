using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.MongoDbEntities
{
    public class Log
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("Description")]
        public string UserId { get; set; }

        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonElement("Operation")]
        public string Operation { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime OperationDate { get; set; } = DateTime.UtcNow;
       
        
    }
}

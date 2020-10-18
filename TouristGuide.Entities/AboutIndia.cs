using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace TouristGuide.Entities
{
    public class AboutIndia
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string About { get; set; }
        public string Visa { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string State { get; set; }
        public string UNION_TERRITORIES { get; set; }
        public string Climate { get; set; }
        public string How_Visit { get; set; }
    }
}

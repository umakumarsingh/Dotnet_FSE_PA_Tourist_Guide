using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristGuide.Entities
{
    public class Place
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Attraction { get; set; }
        //public int Category { get; set; }
        public string Experiences { get; set; }
        public int Distance { get; set; }
        public string DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}

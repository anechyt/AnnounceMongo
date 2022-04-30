using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcement.Domain.Entities
{
    public class Announce : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Price")]
        public decimal Price { get; set; }
        [BsonElement("Date")]
        public DateTime Date { get; set; } = DateTime.Now;
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Photos")]
        public List<string> Photos { get; set; }
    }
}

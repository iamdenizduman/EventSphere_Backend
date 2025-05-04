using EventSphere.Core.Entity.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EventSphere.StockService.Entity.Entities
{
    public class StockHistory : BaseEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string StockId { get; set; }
        
        public string Action { get; set; }
        
        public int QuantityChanged { get; set; }
    }
}

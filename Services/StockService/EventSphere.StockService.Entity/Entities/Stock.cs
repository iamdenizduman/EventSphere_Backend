using EventSphere.Core.Entity.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EventSphere.StockService.Entity.Entities
{
    public class Stock : BaseEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; set; }
        
        [BsonRepresentation(BsonType.Int32)]
        public int EventId { get; set; }
        
        [BsonRepresentation(BsonType.Int32)]
        public int TotalQuantity { get; set; }
        
        [BsonRepresentation(BsonType.Int32)]
        public int AvailableQuantity { get; set; }
        
        [BsonRepresentation(BsonType.Int32)]
        public int SoldQuantity { get; set; }

        [BsonIgnore]
        public ICollection<StockHistory> StockHistories { get; set; }
    }
}

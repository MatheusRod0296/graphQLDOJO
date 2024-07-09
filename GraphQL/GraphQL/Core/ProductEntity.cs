using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GraphQL.Core;

public class ProductEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string CategoryId { get; set; }
}
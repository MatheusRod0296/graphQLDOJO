using GraphQL.Core;
using MongoDB.Driver;

namespace GraphQL.Infra;

public interface ICatalogContext
{
    IMongoCollection<CategoryEntity> Categories { get; }
    IMongoCollection<ProductEntity> Products { get; }
}
using GraphQL.Core;
using MongoDB.Driver;

namespace GraphQL.Infra;

public class CatalogContext: ICatalogContext
{
    private const string ProductCollectionName = "Products";
    private const string CategoryCollectionName = "Categories";
    private readonly IConfiguration Configuration;

    public CatalogContext()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("catalogdb");

        this.Categories = database.GetCollection<CategoryEntity>(CategoryCollectionName);
        this.Products = database.GetCollection<ProductEntity>(ProductCollectionName);

        CatalogContextSeed.SeedData(this.Categories, this.Products);
    }

    public IMongoCollection<CategoryEntity> Categories { get; }
    public IMongoCollection<ProductEntity> Products { get; }
}
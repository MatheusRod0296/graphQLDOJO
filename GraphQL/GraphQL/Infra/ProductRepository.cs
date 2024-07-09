using GraphQL.Core;
using MongoDB.Driver;

namespace GraphQL.Infra;

public class ProductRepository : IProductRepository
{
    private readonly ICatalogContext catalogContext;

    public ProductRepository(ICatalogContext catalogContext)
    {
        this.catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await this.catalogContext.Products.Find(_ => true).ToListAsync();
    }

    public async Task<ProductEntity> GetByIdAsync(string id)
    {
        var filter = Builders<ProductEntity>.Filter.Eq(_ => _.Id, id);

        return await this.catalogContext.Products.Find(filter).FirstOrDefaultAsync();
    }
}
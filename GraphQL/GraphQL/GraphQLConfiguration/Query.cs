using GraphQL.Core;
using HotChocolate;

namespace GraphQL.GraphQLConfiguration;

public class Query
{
    public Task<IEnumerable<ProductEntity>> GetProductsAsync([Service] IProductRepository productRepository) =>
        productRepository.GetAllAsync();

    public Task<ProductEntity> GetProductById(string id, [Service] IProductRepository productRepository) =>
        productRepository.GetByIdAsync(id);
}
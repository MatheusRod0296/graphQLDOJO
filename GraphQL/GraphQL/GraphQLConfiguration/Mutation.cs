using GraphQL.Core;

namespace GraphQL.GraphQLConfiguration;

public class Mutation
{
    public async Task<ProductResult> AddProduct(ProductEntity product, [Service] IProductRepository productRepository)
    {
        await productRepository.AddProduct(product);
        return new ProductResult(product);
    }
    
    public record ProductResult(ProductEntity? product, string? error = null);
}
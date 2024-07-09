namespace GraphQL.Core;

public interface IProductRepository
{
    Task<IEnumerable<ProductEntity>> GetAllAsync();
    Task<ProductEntity> GetByIdAsync(string id);
}
namespace GraphQL.Core;

public interface ICategoryRepository
{
    Task<CategoryEntity> GetById(string id);
}
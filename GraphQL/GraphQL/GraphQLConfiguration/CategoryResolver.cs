using GraphQL.Core;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL.GraphQLConfiguration;

[ExtendObjectType(Name = "CategoryEntity")]
public class CategoryResolver
{
    public Task<CategoryEntity> GetCategoryAsync(
        [Parent] ProductEntity product,
        [Service] ICategoryRepository categoryRepository) => categoryRepository.GetById(product.CategoryId);
}
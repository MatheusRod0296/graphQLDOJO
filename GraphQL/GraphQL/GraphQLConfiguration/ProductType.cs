using GraphQL.Core;
using HotChocolate.Types;

namespace GraphQL.GraphQLConfiguration;

public class ProductType : ObjectType<ProductEntity>
{
    protected override void Configure(IObjectTypeDescriptor<ProductEntity> descriptor)
    {
        descriptor.Field(_ => _.Id);
        descriptor.Field(_ => _.CategoryId);
        descriptor.Field(_ => _.Name);
        descriptor.Field(_ => _.Description);
        descriptor.Field(_ => _.Price);
        descriptor.Field(_ => _.Quantity);
        
        // Creates the relationship between Product x Category
        descriptor.Field<CategoryResolver>(_ => _.GetCategoryAsync(default, default));
    }
}
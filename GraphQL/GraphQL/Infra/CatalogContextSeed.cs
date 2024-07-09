using GraphQL.Core;
using MongoDB.Driver;

namespace GraphQL.Infra;

public class CatalogContextSeed
{
    public static void SeedData(
        IMongoCollection<CategoryEntity> categoryCollection,
        IMongoCollection<ProductEntity> productCollection)
    {
        InsertCategories(categoryCollection);
        InsertProducts(productCollection);
    }

    private static void InsertCategories(IMongoCollection<CategoryEntity> categoryCollection)
    {
        categoryCollection.DeleteMany(_ => true);
        categoryCollection.InsertMany(
            new List<CategoryEntity>
            {
                new CategoryEntity
                {
                    Id = "605fbfdda571444fd7ade05b",
                    Description = "Category Description One"
                },
                new CategoryEntity
                {
                    Id = "605fbfecdefb479679f08517",
                    Description = "Category Description Two"
                }
            });
    }

    private static void InsertProducts(IMongoCollection<ProductEntity> productCollection)
    {
        productCollection.DeleteMany(_ => true);
        productCollection.InsertMany(
            new List<ProductEntity>
            {
                new ProductEntity
                {
                    Id = "605fbfd4f0d09d08fba6bd80",
                    CategoryId = "605fbfdda571444fd7ade05b",
                    Description = "Product Description One",
                    Name = "Product Name One",
                    Price = 10,
                    Quantity = 2
                },
                new ProductEntity
                {
                    Id = "605fbfe4690cd322f1ef0d15",
                    CategoryId = "605fbfecdefb479679f08517",
                    Description = "Product Description Two",
                    Name = "Product Name Two",
                    Price = 15,
                    Quantity = 5
                }
            });
    }
}
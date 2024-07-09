using GraphQL.Core;
using GraphQL.GraphQLConfiguration;
using GraphQL.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<ProductType>()
    .AddType<CategoryResolver>();


builder.Services.AddSingleton<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();


app.UseRouting();
app.MapGraphQL();
// app.UseEndpoints(endpoints =>
//     {
//         endpoints.MapGraphQL("/api/graphql");
//     });

//app.UseHttpsRedirection();
app.Run();

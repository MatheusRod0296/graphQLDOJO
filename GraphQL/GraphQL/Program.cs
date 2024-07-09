using GraphQL.Core;
using GraphQL.GraphQLConfiguration;
using GraphQL.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<ProductType>()
    .AddType<CategoryResolver>()
    .AddMutationType<Mutation>();


builder.Services.AddSingleton<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();


app.UseRouting();
app.MapGraphQL();

app.Run();

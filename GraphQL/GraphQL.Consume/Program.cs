using System.Text;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL.Consume;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger(); 
app.UseSwaggerUI();


app.UseHttpsRedirection();


app.MapGet("/getProductsWithGraphQLClient", async () =>
    {
        var client = new GraphQLHttpClient("http://localhost:5088/graphql/", new NewtonsoftJsonSerializer());

        var request = new GraphQLRequest
        {
            Query =
            
                @"query {
                          products {
                            categoryId
                            description
                            id
                            name
                            price
                            quantity
                          }
                        } "
            
        };

        var result =  await client.SendQueryAsync<Data>(request);
        return result.Data;
    })
    .WithOpenApi();

app.MapGet("/getProductsWithNativeHttpClient", async () =>
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5088/graphql/")
        };
       

        var queryObject = new
        {
            query = @"query {
                          products {
                            categoryId
                            description
                            id
                            name
                            price
                            quantity
                          }
                        } "
        };

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            Content = new StringContent(JsonConvert.SerializeObject(queryObject), Encoding.UTF8, "application/json")
        };

        using (var response = await httpClient.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<Result>(responseString);
            return json;
        }
    })
    .WithOpenApi();

app.Run();

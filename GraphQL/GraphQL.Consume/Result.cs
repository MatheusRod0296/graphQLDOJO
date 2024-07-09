namespace GraphQL.Consume;

public class  Result
{
    public Data Data { get; set; }
}

public class Data
{
    public List<Product> Products { get; set; }
}

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string CategoryId { get; set; }
}
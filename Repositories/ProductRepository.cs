using RedisExemplo.Models;

namespace RedisExemplo.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task<List<Product>> GetAllProductsAsync()
    {
        var productList = new List<Product>()
        {
            new Product() { Id = 1, Nome = "P1" },
            new Product() { Id = 2, Nome = "P2" },
            new Product() { Id = 3, Nome = "P3" }
        };

        return productList;
    }
}
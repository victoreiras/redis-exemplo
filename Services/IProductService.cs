using RedisExemplo.Models;

namespace RedisExemplo.Services;

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync();
}
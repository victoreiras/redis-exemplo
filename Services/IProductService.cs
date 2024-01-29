using RedisExemplo.Models;

namespace RedisExemplo.Services;

public interface IProductService
{
    List<Product> GetAllProducts();
}
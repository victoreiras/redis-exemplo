
using RedisExemplo.Models;

namespace RedisExemplo.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllProductsAsync();
}
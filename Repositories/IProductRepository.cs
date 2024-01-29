
using RedisExemplo.Models;

namespace RedisExemplo.Repositories;

public interface IProductRepository
{
    List<Product> GetAllProducts();
}
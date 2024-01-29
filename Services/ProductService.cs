using RedisExemplo.Models;
using RedisExemplo.Repositories;

namespace RedisExemplo.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICacheService _cacheService;
    private readonly string cacheKey = "products";

    public ProductService(IProductRepository productRepository, ICacheService cacheService)
    {
        _productRepository = productRepository;
        _cacheService = cacheService;
    }
    public List<Product> GetAllProducts()
    {
        var cacheData = _cacheService.GetData<List<Product>>(cacheKey);

        if (cacheData != null)
            return cacheData;

        cacheData = _productRepository.GetAllProducts();

        _cacheService.SetData(cacheKey, cacheData);

        return cacheData;
    }
}
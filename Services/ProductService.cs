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
    public async Task<List<Product>> GetAllProductsAsync()
    {
        var cacheData = await _cacheService.GetDataAsync<List<Product>>(cacheKey);

        if (cacheData is not null)
            return cacheData;

        cacheData = await _productRepository.GetAllProductsAsync();

        _cacheService.SetDataAsync(cacheKey, cacheData);

        return cacheData;
    }
}
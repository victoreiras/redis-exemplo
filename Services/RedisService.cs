
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace RedisExemplo.Services;

public class RedisService : ICacheService
{
    private IDistributedCache _cache;
    private DistributedCacheEntryOptions options;

    public RedisService(IDistributedCache cache)
    {
        _cache = cache;
        options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
            SlidingExpiration = TimeSpan.FromSeconds(1200)
        };
    }
    public async Task<T?> GetDataAsync<T>(string key)
    {
        var value = await _cache.GetStringAsync(key);

        if (value is null)
            return default;

        return JsonSerializer.Deserialize<T>(value);
    }

    public async Task SetDataAsync<T>(string key, T value)
    {
        var jsonValue = JsonSerializer.Serialize(value);
        _cache.SetStringAsync(key, jsonValue, options);
    }

    public async Task RemoveDataAsync(string key)
    {
        var value = await _cache.GetStringAsync(key);

        if (value is not null)
            _cache.Remove(key);
    }
}
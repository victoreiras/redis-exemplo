
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
    public T? GetData<T>(string key)
    {
        var value = _cache.GetString(key);
        if (string.IsNullOrEmpty(value))
            return default;

        return JsonSerializer.Deserialize<T>(value);
    }

    public void SetData<T>(string key, T value)
    {
        var jsonValue = JsonSerializer.Serialize(value);
        _cache.SetString(key, jsonValue, options);
    }

    public void RemoveData(string key)
    {
        var value = _cache.GetString(key);

        if (!string.IsNullOrEmpty(value))
            _cache.Remove(key);
    }
}
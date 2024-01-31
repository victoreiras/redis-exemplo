namespace RedisExemplo.Services;

public interface ICacheService
{
    Task SetDataAsync<T>(string key, T value);
    Task<T?> GetDataAsync<T>(string key);
    Task RemoveDataAsync(string key);
}
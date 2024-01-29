namespace RedisExemplo.Services;

public interface ICacheService
{
    void SetData<T>(string key, T value);
    T? GetData<T>(string key);
    void RemoveData(string key);
}
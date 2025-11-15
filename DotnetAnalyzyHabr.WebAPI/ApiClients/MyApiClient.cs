namespace DotnetAnalyzyHabr.WebAPI.ApiClients;

public interface IMyApiClient
{
    Task<T?> GetAsync<T>(Uri relativeUri);
    Task<TResponse?> PostAsync<TRequest, TResponse>(Uri relativeUri, TRequest payload);
}

public class MyApiClient : IMyApiClient
{
    private readonly HttpClient _httpClient;
    private readonly Uri _baseUri;

    public MyApiClient(
        HttpClient httpClient,
        Uri baseUri
    )
    {
        _httpClient = httpClient;
        _baseUri = baseUri;

    }

    public async Task<TResponse?> GetAsync<TResponse>(Uri relativeUri)
    {
        Uri requestUri = new(_baseUri, relativeUri);

        using HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(Uri relativeUri, TRequest payload)
    {
        Uri requestUri = new(_baseUri, relativeUri);

        using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(requestUri, payload);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>();
    }
}

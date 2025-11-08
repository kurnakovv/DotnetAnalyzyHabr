using System.Net.Http.Headers;

namespace DotnetAnalyzyHabr.WebAPI.ApiClients;

public interface IMyApiClient
{
    Task<T?> GetAsync<T>(Uri relativeUri);
    Task<TResponse?> PostAsync<TRequest, TResponse>(Uri relativeUri, TRequest payload);
}

public class MyApiClient(HttpClient httpClient, Uri baseUri, string accessToken) : IMyApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly Uri _baseUri = baseUri;

    public async Task<TResponse?> GetAsync<TResponse>(Uri relativeUri)  
    {
        var requestUri = new Uri(_baseUri, relativeUri);

        using var response = await _httpClient.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(Uri relativeUri, TRequest payload)
    {
        var requestUri = new Uri(_baseUri, relativeUri);

        using var response = await _httpClient.PostAsJsonAsync(requestUri, payload);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>();
    }
}

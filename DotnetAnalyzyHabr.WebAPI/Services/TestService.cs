namespace DotnetAnalyzyHabr.WebAPI.Services;

public class TestService
{
    private readonly IHttpClientFactory _httpClientFactory;
#pragma warning disable IDISP006 // Implement IDisposable
    private readonly HttpClient _httpClient;
#pragma warning restore IDISP006 // Implement IDisposable

    public TestService(
        IHttpClientFactory httpClientFactory
    )
    {
        _httpClientFactory = httpClientFactory;
        _httpClient = _httpClientFactory.CreateClient();
    }

    public async Task WorkWithIDisposeAsync(IFormFile file)
    {
        using HttpResponseMessage response = await _httpClient.GetAsync(new Uri("uri"));

        // OK
        await using Stream goodStream = file.OpenReadStream();
    }
}

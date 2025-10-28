using System.Net.Http;

namespace DotnetAnalyzyHabr.WebAPI.Services;

public class TestService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;

    public TestService(
        IHttpClientFactory httpClientFactory
    )
    {
        _httpClientFactory = httpClientFactory;
        _httpClient = _httpClientFactory.CreateClient();
    }

    public async Task WorkWithIDisposeAsync(IFormFile file)
    {
        using var response = await _httpClient.GetAsync(new Uri("uri"));
        using Stream stream = file.OpenReadStream();
        stream.Position = 0;

        // IDISP001: Dispose created
        using Stream badStream = file.OpenReadStream();

        // OK
        await using Stream goodStream = file.OpenReadStream();
    }
}

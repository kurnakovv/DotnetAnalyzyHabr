using DotnetAnalyzyHabr.WebAPI.ApiClients;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpClient(
    "MyApiClient",
    client =>
    {
        client.Timeout = TimeSpan.FromSeconds(60);
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    });

builder.Services.AddSingleton<IMyApiClient>(
    sp =>
    {
        IHttpClientFactory httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
#pragma warning disable IDISP001 // Dispose created
        HttpClient httpClient = httpClientFactory.CreateClient("MyApiClient");
#pragma warning restore IDISP001 // Dispose created

        Uri baseUri = new("https://jsonplaceholder.typicode.com/");
        // string accessToken = "your_access_token_here";

        return new MyApiClient(httpClient, baseUri);
    }
);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

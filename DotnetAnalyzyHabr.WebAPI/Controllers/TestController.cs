using DotnetAnalyzyHabr.WebAPI.ApiClients;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAnalyzyHabr.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IMyApiClient _myApiClient;

    public TestController(
        IMyApiClient myApiClient
    )
    {
        _myApiClient = myApiClient;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        Post? post = await _myApiClient.GetAsync<Post>(new Uri("posts/1", UriKind.Relative));
        return Ok(post?.Title);
    }
}

public record Post(int UserId, int Id, string Title, string Body);

using DotnetAnalyzyHabr.WebAPI.ApiClients;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAnalyzyHabr.WebAPI.Controllers;

/// <summary>
/// Test.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IMyApiClient _myApiClient;

    /// <summary>
    /// TestController.
    /// </summary>
    /// <param name="myApiClient">myApiClient.</param>
    public TestController(
        IMyApiClient myApiClient
    )
    {
        _myApiClient = myApiClient;
    }

    /// <summary>
    /// Get test.
    /// </summary>
    /// <returns>test.</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        Post? post = await _myApiClient.GetAsync<Post>(new Uri("posts/1", UriKind.Relative));
        return Ok(post?.Title);
    }
}

/// <summary>
/// Post.
/// </summary>
/// <param name="UserId">UserId.</param>
/// <param name="Id">Id.</param>
/// <param name="Title">Title.</param>
/// <param name="Body">Body.</param>
public record Post(int UserId, int Id, string Title, string Body);

using Microsoft.AspNetCore.Mvc;
using PostService.Core.Api.Services;
using PostService.DataAccessLayer.Models;

namespace PostService.Api.Controllers;

[ApiController]
[Route("controller")]
[Produces("application/json")]
[Consumes("application/json")]
public class PostController: ControllerBase
{
    //Service
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> All()
    {
        return Ok(await _postService.GetAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ById(Guid id)
    {
        return Ok(await _postService.ById(id));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> New(Post post)
    {
        return Ok(await _postService.New(post));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Post post)
    {
        return Ok(await _postService.Update(post));
    }
    
    [HttpDelete]
    [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Post post)
    {
        return Ok(await _postService.Delete(post));
    }
}
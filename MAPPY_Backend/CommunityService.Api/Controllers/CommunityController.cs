using CommunityService.Core.Api.Services;
using CommunityService.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunityService.Api.Controllers;

[ApiController]
[Route("controller")]
[Produces("application/json")]
[Consumes("application/json")]
public class CommunityController: ControllerBase
{
    //Service
    private readonly ICommunityService _communityService;

    public CommunityController(ICommunityService communityService)
    {
        _communityService = communityService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Community), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> All()
    {
        return Ok(await _communityService.GetAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Community), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ById(Guid id)
    {
        return Ok(await _communityService.ById(id));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Community), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> New(Community community)
    {
        return Ok(await _communityService.New(community));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Community), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Community community)
    {
        return Ok(await _communityService.Delete(community));
    }
}
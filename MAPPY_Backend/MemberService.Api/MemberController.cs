using Microsoft.AspNetCore.Mvc;
using MemberService.Core.Api.Services;
using MemberService.DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;

namespace MemberService.Api;

[ApiController]
[Route("controller")]
[Produces("application/json")]
[Consumes("application/json")]
public class MemberController: ControllerBase
{
    //Service
    private readonly IMemberService _memberService;

    public MemberController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Member), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> All()
    {
        return Ok(await _memberService.GetAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Member), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ById(Guid id)
    {
        return Ok(await _memberService.ById(id));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Member), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> New(Member member)
    {
        return Ok(await _memberService.New(member));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Member), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Member member)
    {
        return Ok(await _memberService.Update(member));
    }
    
    [HttpDelete]
    [ProducesResponseType(typeof(Member), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Member member)
    {
        return Ok(await _memberService.Delete(member));
    }
}
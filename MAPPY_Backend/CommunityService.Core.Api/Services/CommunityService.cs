using System.Collections.ObjectModel;
using CommunityService.Core.Api.Contracts;
using CommunityService.DataAccessLayer.Models;

namespace CommunityService.Core.Api.Services;

public class CommunityService: ICommunityService
{
    //Repository
    private readonly ICommunityService _communityService;
    public CommunityService(ICommunityService communityService)
    {
        _communityService = communityService;
    }
    
    public async Task<Collection<Community>> GetAll()
    {
        return await _communityService.GetAll();
    }

    public async Task<Community> ById(Guid id)
    {
        return await _communityService.ById(id);
    }

    public async Task<CommunityResponse> New(Community community)
    {
        await _communityService.New(community);
        var response = new CommunityResponse();
        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }

    public async Task<CommunityResponse> Update(Community community)
    {
        await _communityService.Update(community);
        var response = new CommunityResponse();
        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }

    public async Task<CommunityResponse> Delete(Community community)
    {
        await _communityService.Delete(community);
        var response = new CommunityResponse();
        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }
}
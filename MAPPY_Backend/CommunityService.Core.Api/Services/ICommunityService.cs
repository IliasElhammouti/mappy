using System.Collections.ObjectModel;
using CommunityService.Core.Api.Contracts;
using CommunityService.DataAccessLayer.Models;

namespace CommunityService.Core.Api.Services;

public interface ICommunityService
{
    Task<Collection<Community>> GetAll();
    Task<Community> ById(Guid id);
    Task<CommunityResponse> New(Community community);
    Task<CommunityResponse> Update(Community community);
    Task<CommunityResponse> Delete(Community community);
}
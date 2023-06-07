using System.Collections.ObjectModel;
using CommunityService.DataAccessLayer.Models;

namespace CommunityService.DataAccessLayer.Repositories;

public interface ICommunityRepository
{
    Task<Collection<Community>> GetAll();
    Task<Community?> ById(Guid id);
    Task New(Community community);
    Task Update(Community community);
    Task Delete(Community community);
}
using System.Collections.ObjectModel;
using CommunityService.DataAccessLayer.Context;
using CommunityService.DataAccessLayer.Models;

namespace CommunityService.DataAccessLayer.Repositories;

public class CommunityRepository: ICommunityRepository
{
    //Context
    private readonly CommunityDbContext _communityDbContext;

    public CommunityRepository(CommunityDbContext communityDbContext)
    {
        _communityDbContext = communityDbContext;
    }
    
    public async Task<Collection<Community>> GetAll()
    {
        return await Task.FromResult(new Collection<Community>(_communityDbContext.Communities.ToList()));
    }

    public async Task<Community?> ById(Guid id)
    {
        return await Task.FromResult(_communityDbContext.Communities.FirstOrDefault(m => m.Id == id));
    }

    public async Task New(Community community)
    {
        await _communityDbContext.Communities.AddAsync(community);
        await _communityDbContext.SaveChangesAsync();
    }

    public async Task Update(Community community)
    {
        _communityDbContext.Update(community);
        await _communityDbContext.SaveChangesAsync();
    }

    public async Task Delete(Community community)
    {
        _communityDbContext.Remove(community);
        await _communityDbContext.SaveChangesAsync();
    }
}
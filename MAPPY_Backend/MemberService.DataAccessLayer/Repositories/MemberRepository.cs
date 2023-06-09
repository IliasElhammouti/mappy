using System.Collections.ObjectModel;
using MemberService.DataAccessLayer.Context;
using MemberService.DataAccessLayer.Models;

namespace MemberService.DataAccessLayer.Repositories;

public class MemberRepository : IMemberRepository
{
    //Context
    private readonly MemberDbContext _memberDbContext;

    public MemberRepository(MemberDbContext memberDbContext)
    {
        _memberDbContext = memberDbContext;
    }

    public async Task<Collection<Member>> GetAll()
    {
        return await Task.FromResult(new Collection<Member>(_memberDbContext.Members.ToList()));
    }

    public async Task<Member?> ById(Guid id)
    {
        return await Task.FromResult(_memberDbContext.Members.FirstOrDefault(m => m.Id == id));
    }

    public async Task New(Member member)
    {
        await _memberDbContext.Members.AddAsync(member);
        await _memberDbContext.SaveChangesAsync();
    }

    public async Task Update(Member member)
    {
        _memberDbContext.Update(member);
        await _memberDbContext.SaveChangesAsync();
    }

    public async Task Delete(Member member)
    {
        _memberDbContext.Remove(member);
        await _memberDbContext.SaveChangesAsync();
    }
}
using System.Collections.ObjectModel;
using MemberService.DataAccessLayer.Models;

namespace MemberService.DataAccessLayer.Repositories;

public interface IMemberRepository
{
    Task<Collection<Member>> GetAll();
    Task<Member?> ById(Guid id);
    Task New(Member member);
    Task Update(Member member);
    Task Delete(Member member);
}
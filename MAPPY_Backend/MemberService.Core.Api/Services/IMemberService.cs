using System.Collections.ObjectModel;
using MemberService.Core.Api.Contracts;
using MemberService.DataAccessLayer.Models;

namespace MemberService.Core.Api.Services;

public interface IMemberService
{
    Task<Collection<Member>> GetAll();
    Task<Member> ById(Guid id);
    Task<MemberResponse> New(Member member);
    Task<MemberResponse> Update(Member member);
    Task<MemberResponse> Delete(Member member);
}
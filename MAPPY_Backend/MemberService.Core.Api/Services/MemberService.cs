using System.Collections.ObjectModel;
using MemberService.Core.Api.Contracts;
using MemberService.DataAccessLayer.Models;
using MemberService.DataAccessLayer.Repositories;

namespace MemberService.Core.Api.Services;

public class MemberService : IMemberService
{
    //Repository
    private readonly IMemberRepository _memberRepository;

    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }
    
    public async Task<Collection<Member>> GetAll()
    {
        return await _memberRepository.GetAll();
    }

    public async Task<Member> ById(Guid id)
    {
        return await _memberRepository.ById(id);
    }

    public async Task<MemberResponse> New(Member member)
    {
        await _memberRepository.New(member);
        var response = new MemberResponse();
        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }

    public async Task<MemberResponse> Update(Member member)
    {
        await _memberRepository.Update(member);
        var response = new MemberResponse();
        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }

    public async Task<MemberResponse> Delete(Member member)
    {
        await _memberRepository.Delete(member);
        var response = new MemberResponse();
        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }
}
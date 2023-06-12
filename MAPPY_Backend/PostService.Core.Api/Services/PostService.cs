using System.Collections.ObjectModel;
using PostService.Core.Api.Contracts;
using PostService.DataAccessLayer.Models;

namespace PostService.Core.Api.Services;

public class PostService: IPostService
{
    //Repository
    private readonly IPostService _postService;
    public PostService(IPostService postService)
    {
        _postService = postService;
    }
    public async Task<Collection<Post>> GetAll()
    {
        return await _postService.GetAll();
    }

    public async Task<Post> ById(Guid id)
    {
        return await _postService.ById(id);
    }

    public async Task<PostResponse> New(Post post)
    {
        await _postService.New(post);
        var response = new PostResponse();
        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }

    public async Task<PostResponse> Update(Post post)
    {
        await _postService.Update(post);
        var response = new PostResponse();
        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }

    public async Task<PostResponse> Delete(Post post)
    {
        await _postService.Delete(post);
        var response = new PostResponse();
        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }
}
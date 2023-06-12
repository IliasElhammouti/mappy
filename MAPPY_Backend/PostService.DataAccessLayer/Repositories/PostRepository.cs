using System.Collections.ObjectModel;
using PostService.DataAccessLayer.Context;
using PostService.DataAccessLayer.Models;

namespace PostService.DataAccessLayer.Repositories;

public class PostRepository : IPostRepository
{
    //Context
    private readonly PostDbContext _postDbContext;

    public PostRepository(PostDbContext postDbContext)
    {
        _postDbContext = postDbContext;
    }

    public async Task<Collection<Post>> GetAll()
    {
        return await Task.FromResult(new Collection<Post>(_postDbContext.Posts.ToList()));
    }

    public async Task<Post?> ById(Guid id)
    {
        return await Task.FromResult(_postDbContext.Posts.FirstOrDefault(m => m.Id == id));
    }

    public async Task New(Post post)
    {
        await _postDbContext.Posts.AddAsync(post);
        await _postDbContext.SaveChangesAsync();
    }

    public async Task Update(Post post)
    {
        _postDbContext.Update(post);
        await _postDbContext.SaveChangesAsync();
    }

    public async Task Delete(Post post)
    {
        _postDbContext.Remove(post);
        await _postDbContext.SaveChangesAsync();
    }
}
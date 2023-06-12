using System.Collections.ObjectModel;
using PostService.Core.Api.Contracts;
using PostService.DataAccessLayer.Models;

namespace PostService.Core.Api.Services;

public interface IPostService
{
    Task<Collection<Post>> GetAll();
    Task<Post> ById(Guid id);
    Task<PostResponse> New(Post post);
    Task<PostResponse> Update(Post post);
    Task<PostResponse> Delete(Post post);
}
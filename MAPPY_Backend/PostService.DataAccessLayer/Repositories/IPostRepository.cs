using System.Collections.ObjectModel;
using PostService.DataAccessLayer.Models;

namespace PostService.DataAccessLayer.Repositories;

public interface IPostRepository
{
    Task<Collection<Post>> GetAll();
    Task<Post?> ById(Guid id);
    Task New(Post post);
    Task Update(Post post);
    Task Delete(Post post);
}
using Application.Entities.Base;
using Application.Entities.Base.Post;
using Application.Entities.DTOs;
using Application.Request.Post;
using System.Linq.Expressions;

namespace Application.Interface.IRepositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPost();
        Task<PagedResult<Post>> GetAllPostWithSearchAndSort(PostSearchRequest request);
        Task<IEnumerable<Post>> GetAllPostBy(Expression<Func<Post, bool>> predicate);
        Task<Post> GetPostById(Guid PostId);
        Task<Post> GetPostBy(Expression<Func<Post, bool>> predicate);
        Task CreatePost(Post Post);
        Task UpdatePost(Post Post);
        Task DeletePost(Guid PostId);
        Task<User> GetUserById(Guid userId);
    }
}

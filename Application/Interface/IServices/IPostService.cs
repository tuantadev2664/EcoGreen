using Application.Entities.Base.Post;
using Application.Request.Post;
using Application.Response;
using System.Linq.Expressions;

namespace Application.Interface.IServices
{
    public interface IPostService
    {
        Task<APIResponse> GetPostById(Guid activityId);
        Task<APIResponse> GetAllPosts();
        Task<APIResponse> GetAllPostsWithSearchAndSort(PostSearchRequest request);
        Task<APIResponse> GetAllPostsBy(Expression<Func<Post, bool>> predicate);
        Task<APIResponse> GetPostBy(Expression<Func<Post, bool>> predicate);
        Task<APIResponse> CreatePost(Post Post);
        Task<APIResponse> UpdatePost(Post Post);
        Task<APIResponse> DeletePost(Guid activityId);
    }
}

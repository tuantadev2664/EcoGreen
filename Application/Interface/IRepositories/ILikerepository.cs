using Application.Entities.Base.Post;

namespace Application.Interface.IRepositories
{
    public interface ILikeRepository
    {
        Task<Like?> GetLikeByPostAndUserAsync(Guid postId, Guid userId);
        Task AddLikeAsync(Like like);
        Task RemoveLikeAsync(Like like);
        Task SaveChangesAsync();
    }

}

using Application.Entities.Base.Post;

namespace Application.Interface.IRepositories
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);
        Task SaveChangesAsync();
    }

}

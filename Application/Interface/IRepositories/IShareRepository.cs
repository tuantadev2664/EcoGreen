using Application.Entities.Base.Post;

namespace Application.Interface.IRepositories
{
    public interface IShareRepository
    {
        Task AddShareAsync(Share share);
        Task SaveChangesAsync();
    }
}

using Application.Interface.IRepositories;

namespace Application.Interface
{
    public interface IUnitOfWork
    {
        ITokenRepository TokenRepository { get; }
        Task<int> SaveChangesAsync();
    }

}

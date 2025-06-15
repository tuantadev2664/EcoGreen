namespace Application.Interface
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }

}

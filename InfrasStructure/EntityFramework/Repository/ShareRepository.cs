using Application.Entities.Base.Post;
using Application.Interface.IRepositories;
using InfrasStructure.EntityFramework.Data;

namespace InfrasStructure.EntityFramework.Repository
{
    public class ShareRepository : IShareRepository
    {
        private readonly ApplicationDBContext _context;

        public ShareRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddShareAsync(Share share)
        {
            await _context.Shares.AddAsync(share);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

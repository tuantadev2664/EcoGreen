using Application.Interface;
using Application.Interface.IRepositories;
using InfrasStructure.EntityFramework.Data;
using InfrasStructure.EntityFramework.Repository;

namespace EcoGreen.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;

        public UnitOfWork(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

            TokenRepository = new TokenRepository(_configuration);
        }

        public ITokenRepository TokenRepository { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

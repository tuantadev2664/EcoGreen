using Application.Entities.Base.Post;
using Application.Interface.IRepositories;
using InfrasStructure.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrasStructure.EntityFramework.Repository
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDBContext _context;

        public LikeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Like?> GetLikeByPostAndUserAsync(Guid postId, Guid userId)
        {
            return await _context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
        }

        public async Task AddLikeAsync(Like like)
        {
            await _context.Likes.AddAsync(like);
        }

        public async Task RemoveLikeAsync(Like like)
        {
            _context.Likes.Remove(like);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}

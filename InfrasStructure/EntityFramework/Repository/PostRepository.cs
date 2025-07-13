using Application.Entities.Base;
using Application.Entities.Base.Post;
using Application.Entities.DTOs;
using Application.Interface;
using Application.Interface.IRepositories;
using Application.Request.Post;
using InfrasStructure.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InfrasStructure.EntityFramework.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public PostRepository(ApplicationDBContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task CreatePost(Post Post)
        {
            Post.CreatedAt = DateTime.UtcNow;
            await _context.Posts.AddAsync(Post);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task DeletePost(Guid PostId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetAllPost()
        {
            return await _context.Posts
                                   .Include(a => a.User)
                                   .AsNoTracking()
                                   .ToListAsync();

        }

        public async Task<IEnumerable<Post>> GetAllPostBy(Expression<Func<Post, bool>> predicate)
        {
            return await _context.Posts
                               .Where(predicate)
                               .Include(a => a.User)
                               .AsNoTracking()
                               .ToListAsync();
        }

        public async Task<PagedResult<Post>> GetAllPostWithSearchAndSort(PostSearchRequest request)
        {
            var query = _context.Posts.Include(a => a.User).AsQueryable();

            // Apply search filters
            query = ApplySearchFilters(query, request);

            // Get total count before pagination
            var totalRecords = await query.CountAsync();

            // Apply sorting
            query = ApplySorting(query, request.SortBy, request.SortDirection);

            // Apply pagination
            var posts = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .AsNoTracking()
                .ToListAsync();

            return PagedResult<Post>.Create(
                posts,
                totalRecords,
                request.Page,
                request.PageSize,
                request.SearchTerm,
                request.SortBy,
                request.SortDirection.ToString()
            );
        }

        public async Task<Post?> GetPostBy(Expression<Func<Post, bool>> predicate)
        {
            return await _context.Posts
                           .Include(a => a.User)
                           .FirstOrDefaultAsync(predicate);
        }

        public async Task<Post?> GetPostById(Guid PostId)
        {
            return await _context.Posts
                                .Include(a => a.User)
                                .FirstOrDefaultAsync(a => a.Id == PostId);
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task UpdatePost(Post Post)
        {
            var existingPost = await _context.Posts.FindAsync(Post.Id);

            if (existingPost == null)
            {
                throw new KeyNotFoundException($"Post with ID {Post.Id} not found.");
            }

            _context.Entry(existingPost).CurrentValues.SetValues(Post);

            existingPost.CreatedAt = DateTime.SpecifyKind(existingPost.CreatedAt, DateTimeKind.Utc);

            _context.Entry(existingPost).Property(p => p.UserId).IsModified = false;

            await _unitOfWork.SaveChangesAsync();
        }
        private IQueryable<Post> ApplySearchFilters(IQueryable<Post> query, PostSearchRequest request)
        {
            // Global search term (searches in title, description, location)
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.ToLower();
                query = query.Where(a =>
                    a.Content.ToLower().Contains(searchTerm) ||
                    a.User.UserName.ToLower().Contains(searchTerm)
                );
            }

            // Specific field filters
            if (!string.IsNullOrWhiteSpace(request.Content))
            {
                query = query.Where(a => a.Content.ToLower().Contains(request.Content.ToLower()));
            }
            // Date range filters
            if (request.DateFrom.HasValue)
            {
                query = query.Where(a => a.CreatedAt >= request.DateFrom.Value);
            }

            if (request.DateTo.HasValue)
            {
                query = query.Where(a => a.CreatedAt <= request.DateTo.Value);
            }

            return query;
        }

        private IQueryable<Post> ApplySorting(IQueryable<Post> query, string? sortBy, Application.Request.SortDirection sortDirection)
        {
            if (string.IsNullOrWhiteSpace(sortBy) || !PostSortFields.IsValidSortField(sortBy))
            {
                sortBy = PostSortFields.CreatedAt; // Default sort
            }

            var isDescending = sortDirection == Application.Request.SortDirection.Desc;

            return sortBy.ToLower() switch
            {
                "content" => isDescending ? query.OrderByDescending(a => a.Content) : query.OrderBy(a => a.Content),
                "createdat" => isDescending ? query.OrderByDescending(a => a.CreatedAt) : query.OrderBy(a => a.CreatedAt),
                "createdbyuserid" => isDescending ? query.OrderByDescending(a => a.UserId) : query.OrderBy(a => a.UserId),
                _ => isDescending ? query.OrderByDescending(a => a.CreatedAt) : query.OrderBy(a => a.CreatedAt)
            };
        }
    }
}

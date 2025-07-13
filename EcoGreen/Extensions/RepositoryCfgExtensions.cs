using Application.Interface.IRepositories;
using InfrasStructure.EntityFramework.Repository;

namespace EcoGreen.Extensions
{
    public static class RepositoryCfgExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ICompanyFormRepository, CompanyFormRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IShareRepository, ShareRepository>();
            return services;
        }
    }
}

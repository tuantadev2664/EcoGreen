using Application.Interface;
using Application.Interface.IServices;
using EcoGreen.Helpers;
using EcoGreen.Service;

namespace EcoGreen.Extensions
{
    public static class ServiceCfgExtension
    {
        public static IServiceCollection AddService(this IServiceCollection Services)
        {
            Services.AddScoped<ICompanyFormService, CompanyFormService>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddSingleton<CloudinaryService>();
            Services.AddScoped<IPostService, PostService>();
            Services.AddScoped<ILikeService, LikeService>();
            Services.AddScoped<ICommentService, CommentService>();
            Services.AddScoped<IShareService, ShareService>();
            //Services.AddSingleton<AIChatService>();

            return Services;
        }
    }
}

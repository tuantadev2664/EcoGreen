using Application.Interface;
using Application.Interface.IServices;
using EcoGreen.Helpers;
using EcoGreen.Service;
using EcoGreen.Services;

namespace EcoGreen.Extensions
{
    public static class ServiceCfgExtension
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ICompanyFormService, CompanyFormService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddSingleton<CloudinaryService>();
            //services.AddSingleton<AIChatService>();

            return services;
        }
    }
}

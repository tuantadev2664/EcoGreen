using Application.Interface;
using Application.Interface.IServices;
using EcoGreen.Helpers;
using EcoGreen.Service;

namespace EcoGreen.Extensions
{
    public static class ServiceCfgExtension
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ICompanyFormService, CompanyFormService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

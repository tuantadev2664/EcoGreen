using Application.Interface.IRepositories;
using InfrasStructure.EntityFramework.Repository;

namespace EcoGreen.Extensions
{
    public static class RepositoryCfgExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ICompanyFormRepository, CompanyFormRepository>();
            return services;
        }
    }
}

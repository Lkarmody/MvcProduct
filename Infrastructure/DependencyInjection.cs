using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
           this IServiceCollection services, IConfiguration config)
        {
            // Register EF Core DbContext
            services.AddDbContext<MvcProductContext>(options =>
                options.UseSqlServer(
                    config.GetConnectionString("MvcProductContext") ??
                    throw new InvalidOperationException("Connection string 'MvcProductContext' not found.")
                ));

            // Register repositories & services
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddTransient<ICalculator, Calculator>();

            return services;

        }
    }
}

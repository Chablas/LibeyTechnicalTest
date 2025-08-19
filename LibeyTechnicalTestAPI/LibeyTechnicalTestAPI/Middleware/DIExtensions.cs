using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibeyTechnicalTestAPI.Middleware
{
    public static class DIExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ILibeyUserRepository, LibeyUserRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IUbigeoRepository, UbigeoRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();

            return services;
        }
    }
}
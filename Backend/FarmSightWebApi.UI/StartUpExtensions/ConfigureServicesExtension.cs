using FamSightWebApi.Core.Domain.RepositoryContracts;
using FarmSightWebApi.Application.Services;
using FarmSightWebApi.Core.ServiceContracts;
using FarmSightWebApi.Infrastructure.DatabaseContext;
using FarmSightWebApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FarmSightWebApi.UI
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //it adds controllers and views as services
            services.AddControllers();

            //add services into IoC container
            services.AddScoped<IFieldRepository, FieldRepository>();

            services.AddScoped<IFieldService, FieldService>();

            services.AddDbContext<FarmSightDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
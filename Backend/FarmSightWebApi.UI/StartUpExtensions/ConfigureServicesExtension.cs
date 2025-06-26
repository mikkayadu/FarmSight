using FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts;
using FarmSightWebApi.ApplicationCore.ServiceContracts;
using FarmSightWebApi.ApplicationCore.Services;
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

            services.AddScoped<IFarmerService, FarmerService>();

            services.AddScoped<IFarmerRepository, FarmerRepository>();


            services.AddDbContext<FarmSightDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
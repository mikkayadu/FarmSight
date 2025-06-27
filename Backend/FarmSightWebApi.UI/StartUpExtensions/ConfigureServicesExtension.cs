using FarmSightWebApi.ApplicationCore.Domain.Identity;
using FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts;
using FarmSightWebApi.ApplicationCore.ServiceContracts;
using FarmSightWebApi.ApplicationCore.Services;
using FarmSightWebApi.Infrastructure.BackgroundServices;
using FarmSightWebApi.Infrastructure.DatabaseContext;
using FarmSightWebApi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            services.AddScoped<IEODataRepository, EODataRepository>();

            services.AddScoped<IEODataService, EODataService>();

            services.AddScoped<IYieldForecastRepository, YieldForecastRepository>();

            services.AddScoped<IYieldForecastService, YieldForecastService>();

            services.AddScoped<ICropCalendarRepository, CropCalendarRepository>();

            services.AddScoped<ICropCalendarService, CropCalendarService>();

            services.AddScoped<IAlertRepository, AlertRepository>();

            services.AddScoped<IAlertService, AlertService>();

            services.AddScoped<IBenchmarkSnapshotRepository, BenchmarkSnapshotRepository>();

            services.AddScoped<IBenchmarkSnapshotService, BenchmarkSnapshotService>();

            services.AddScoped<IEODataFetchService, EODataFetchService>();

            services.AddScoped<IEODataFetchService, EODataFetchService>();

            services.AddHostedService<EODataIngestionJob>();

            services.AddHttpClient<IEODataFetchService, EODataFetchService>();

            services.AddDbContext<FarmSightDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            // Add Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<FarmSightDbContext>()
                .AddDefaultTokenProviders();

            // JWT Settings
            var jwtSettings = configuration.GetSection("Jwt");
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!))
                };
            });

            services.AddAuthorization();


            return services;
        }
    }
}
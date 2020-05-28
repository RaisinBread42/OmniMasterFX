using OmniMasterFX.Application.Common.Interfaces;
using OmniMasterFX.Infrastructure.Files;
using OmniMasterFX.Infrastructure.Persistence;
using OmniMasterFX.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmniMasterFX.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace OmniMasterFX.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {
            if (Configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseInMemoryDatabase("OmniAuthMasterFX"));

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("OmniMasterFX"));
            }
            else
            {
                services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AuthConnection"),
                    b => b.MigrationsAssembly(typeof(AuthDbContext).Assembly.FullName)));

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IAuthDbContext>(provider => provider.GetService<AuthDbContext>());
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
            return services;
        }
    }
}

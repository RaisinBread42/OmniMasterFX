using IdentityServer4;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using OmniAuthMasterFX;
using OmniMasterFX.Infrastructure.Identity;
using OmniMasterFX.Infrastructure.Persistence;

namespace OmniMasterFX.Auth
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthenticationService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddIdentityServer()
                .AddInMemoryPersistedGrants()
                .AddDeveloperSigningCredential()
                .AddInMemoryPersistedGrants()
                .AddInMemoryIdentityResources(AuthConfig.GetIdentityResources())
                .AddInMemoryApiResources(AuthConfig.GetApiResources())
                .AddInMemoryClients(AuthConfig.GetClients())
                .AddAspNetIdentity<AuthDbContext>();

            services.AddMvc();

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddIdentityServerAuthentication("Bearer", options =>
            {
                options.Authority = "https://localhost:44312/";
                options.RequireHttpsMetadata = false;
                options.ApiName = "api1";
            })
            .AddCookie();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Cookie", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.AuthenticationSchemes.Add(CookieAuthenticationDefaults.AuthenticationScheme);
                });
            });

            //uncomment below to see debug info on auth failure exceptions
            //IdentityModelEventSource.ShowPII = true; 
            return services;
        }
    }
}

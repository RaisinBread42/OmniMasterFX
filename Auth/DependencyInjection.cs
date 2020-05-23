using IdentityServer4;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace OmniMasterFX.Auth
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthenticationService(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddIdentityServer()
            //    .AddInMemoryPersistedGrants()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryPersistedGrants()
            //    .AddInMemoryIdentityResources(AuthConfig.GetIdentityResources())
            //    .AddInMemoryApiResources(AuthConfig.GetApiResources())
            //    .AddInMemoryClients(AuthConfig.GetClients())
            //    .AddAspNetIdentity<ApplicationUser>();

            services.AddMvc();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddIdentityServerAuthentication("Bearer", options =>
            {
                options.Authority = "https://localhost:44315/";
                options.RequireHttpsMetadata = false;
                options.ApiName = "api1";
            });

            IdentityModelEventSource.ShowPII = true;
            return services;
        }
    }
}

using System.Reflection;
using Chronicle.Application.Identity;
using Chronicle.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Chronicle.Application
{
    public static class CompositionRoot
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Register services here

            services.AddTransient<IJwtTokenProvider, JwtTokenProvider>();

            services.AddTransient<ICryptoService, CryptoService>();
            services.AddTransient<IUserService, UserService>();
        }

        public static readonly Assembly Assembly = typeof(CompositionRoot).Assembly;
    }
}

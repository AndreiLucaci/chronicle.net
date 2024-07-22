using System.Text;
using Chronicle.Application.Repository;
using Chronicle.Domain.Identity;
using Chronicle.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Chronicle.Api.Configuration
{
    public static class IdentityConfiguration
    {
        public static WebApplicationBuilder AddIdentityConfiguration(
            this WebApplicationBuilder builder
        )
        {
            builder
                .Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                })
                .AddCookie(IdentityConstants.ApplicationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Constants.JwtConfig.Issuer,
                        ValidAudience = Constants.JwtConfig.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Constants.JwtConfig.SigningKey)
                        )
                    };
                });

            builder.Services.AddAuthorizationBuilder();

            var connectionString = Constants.SqliteConfig.ConnectionString;
            builder.Services.AddDbContext<IdentityApplicationDbContext>(options =>
                options.UseSqlite(
                    connectionString,
                    x => x.MigrationsAssembly("Chronicle.Application")
                )
            );

            builder
                .Services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityApplicationDbContext>()
                .AddApiEndpoints()
                .AddDefaultTokenProviders();

            return builder;
        }
    }
}

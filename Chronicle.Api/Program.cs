using Chronicle.Api.Configuration;
using Chronicle.Application;
using Chronicle.Utils;
using Chronicle.Utils.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

if (string.IsNullOrEmpty(Constants.MongoConfig.ConnectionString))
{
    throw new MongoDbConnectionUriNotSet("MongoDB connection URI not set");
}

var builder = WebApplication.CreateBuilder(args);


{
    // Add services to the container.
    builder.AddIdentityConfiguration();

    builder.Services.AddApplicationServices();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(x =>
    {
        x.AddSecurityDefinition(
            JwtBearerDefaults.AuthenticationScheme,
            new OpenApiSecurityScheme
            {
                Name = JwtBearerDefaults.AuthenticationScheme,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme.",
                Type = SecuritySchemeType.Http
            }
        );
        x.AddSecurityRequirement(
            new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    new string[] { }
                }
            }
        );
    });
    builder.Services.AddControllers();
    builder.Services.AddMediatR(options =>
        options.RegisterServicesFromAssemblies(Chronicle.Application.CompositionRoot.Assembly)
    );
}

var app = builder.Build();


{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(x =>
        {
            x.DocumentTitle = "Chronicle API";
        });
    }

    // app.MapIdentityApi<ApplicationUser>();

    app.MapControllers();

    app.UseHttpsRedirection();
}

app.Run();

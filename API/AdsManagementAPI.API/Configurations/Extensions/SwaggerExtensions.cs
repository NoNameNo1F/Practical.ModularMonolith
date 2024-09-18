using System.Reflection;
using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace AdsManagementAPI.API.Configurations.Extensions;

internal static class SwaggerExtensions
{
    internal static IServiceCollection AddApiSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AdsManagement API",
                Version = "v1",
                Description = "AdsManagement API for modular monolith .NET application"
            });
            options.CustomSchemaIds(t => t.ToString());
            
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var commentsFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var commentsFile = Path.Combine(baseDirectory, commentsFileName);
            //options.IncludeXmlComments(commentsFile);
            
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });

        return services;
    }

    internal static WebApplication UseSwaggerDocumentation(this WebApplication app)
    {
        app.UseSwagger();

        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwaggerUI(options =>
        {
            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        });

        return app;
    }
}
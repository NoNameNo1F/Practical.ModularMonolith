

using AdsManagementAPI.API.Common;
using AdsManagementAPI.API.Configurations.Extensions;
using AdsManagementAPI.Modules.Auth.Infrastructure.Configuration.Auth;
using AdsManagementAPI.Modules.Auth.Infrastructure.Token;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();


// Extensions
builder.Services.AddApiSwaggerDocumentation();
builder.Services.AddApiVersions();
builder.Services.AddApiAuthentication(builder.Configuration);
builder.Services.AddApiAuthorization();

//Registering Module
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((container) =>
    {
        var logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console(
                outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        var tokensConfiguration = new TokensConfiguration(
            builder.Configuration["Jwt:Issuer"],
            builder.Configuration["Jwt:Audience"],
            builder.Configuration["Jwt:Key"]
        );
        
        // Register module here
        container.RegisterModule(new AuthAutoFacModule());

        // Initialize module here

        AdsManagementAPI.Modules.Auth.Infrastructure.Configuration.Startup.Initialize(
            builder.Configuration.GetConnectionString(
                builder.Configuration["Databases:AuthModuleDb:Sql:ConnectionString"]),
            logger,
            tokensConfiguration
        );
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();

    app.UseCors(options => options
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders(HeaderConstraints.XPagination));
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
using AdsManagementAPI.BuildingBlocks.Application.Data;
using AdsManagementAPI.BuildingBlocks.Infrastructure;
using AdsManagementAPI.Modules.Auth.Infrastructure.Database;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Configuration.DataAccess;

internal class DataAccessModule : Autofac.Module
{
    private readonly string _databaseConnectionString;
    private readonly ILoggerFactory _loggerFactory;

    internal DataAccessModule(string databaseConnectionString, ILoggerFactory loggerFactory)
    {
        _databaseConnectionString = databaseConnectionString;
        _loggerFactory = loggerFactory;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SqlConnectionFactory>()
            .As<ISqlConnectionFactory>()
            .WithParameter("connectionString", _databaseConnectionString)
            .InstancePerLifetimeScope();

        builder.Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<AuthContext>();
                dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);

                return new AuthContext(dbContextOptionsBuilder.Options, _loggerFactory);
            })
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();

        var infrastructureAssembly = typeof(AuthContext).Assembly;

        builder.RegisterAssemblyTypes(infrastructureAssembly)
            .Where(type => type.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope()
            .FindConstructorsWith(new AllConstructorFinder());
    }
}
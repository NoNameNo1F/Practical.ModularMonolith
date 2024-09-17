using AdsManagementAPI.Modules.Auth.Infrastructure.Configuration.DataAccess;
using AdsManagementAPI.Modules.Auth.Infrastructure.Configuration.Logging;
using AdsManagementAPI.Modules.Auth.Infrastructure.Configuration.Mediator;
using Autofac;
using Serilog.Extensions.Logging;
using ILogger = Serilog.ILogger;

// using ILogger = Serilog.ILogger;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Configuration;

public class Startup
{
    private static IContainer _container;
    public static void Initialize(
        string connectionString,
        ILogger logger
        //EmailsConfiguration emailsConfiguration,
        //IEventsBus eventsBus
    )
    {
        var moduleLogger = logger.ForContext("Module", "Auth");

        ConfigureCompositionRoot(
            connectionString,
            //emailsConfiguration,
            //eventsBus,
            moduleLogger
        );
        
        // EventsBusStartup.Initialize(moduleLogger);
    }

    private static void ConfigureCompositionRoot(
        string connectionString,
        //EmailsConfiguration emailsConfiguration,
        //IEventsBus eventsBus,
        ILogger logger)
    {
        var containerBuilder = new ContainerBuilder();

        containerBuilder.RegisterModule(new LoggingModule(logger));

        var loggerFactory = new Serilog.Extensions.Logging.SerilogLoggerFactory(logger);

        containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
        containerBuilder.RegisterModule(new MediatorModule());
        
        // containerBuilder.RegisterModule(new EmailModule(emailsConfiguration));
        // containerBuilder.RegisterModule(new EventsBusModule(eventsBus));

        _container = containerBuilder.Build();
        CompositionRoot.SetContainer(_container);
    }
}
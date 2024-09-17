using AdsManagementAPI.Modules.Auth.Application.Contracts;
using Autofac;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Configuration.Auth;

public class AuthAutoFacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AuthModule>()
            .As<IAuthModule>()
            .InstancePerLifetimeScope();
    }
}
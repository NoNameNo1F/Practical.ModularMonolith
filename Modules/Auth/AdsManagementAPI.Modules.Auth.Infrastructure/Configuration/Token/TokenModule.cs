using AdsManagementAPI.Modules.Auth.Application.Tokens;
using AdsManagementAPI.Modules.Auth.Infrastructure.Token;
using Autofac;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Configuration.Token;

public class TokenModule : Module
{
    private readonly TokensConfiguration _configuration;

    public TokenModule(TokensConfiguration configuration)
    {
        this._configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TokenService>()
            .As<ITokenService>()
            .WithParameter("configuration", _configuration)
            .InstancePerLifetimeScope();
    }
}
using AdsManagementAPI.Modules.Auth.Application.Contracts;
using AdsManagementAPI.Modules.Auth.Infrastructure.Configuration;
using AdsManagementAPI.Modules.Auth.Infrastructure.Configuration.Processing;
using MediatR;
using Autofac;

namespace AdsManagementAPI.Modules.Auth.Infrastructure;
public class AuthModule : IAuthModule
{
    public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
    {
        return await CommandsExecutor.Execute(command);
    }

    public async Task ExecuteCommandAsync(ICommand command)
    {
        await CommandsExecutor.Execute(command);
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        using (var scope = CompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();

            return await mediator.Send(query);
        }
    }
}
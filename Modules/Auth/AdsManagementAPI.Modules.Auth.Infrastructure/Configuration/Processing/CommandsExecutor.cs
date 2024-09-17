using AdsManagementAPI.Modules.Auth.Application.Contracts;
using Autofac;
using MediatR;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Configuration.Processing;

internal class CommandsExecutor
{
    internal static async Task Execute(ICommand command)
    {
        using (var scope = CompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();
            await mediator.Send(command);
        }
    }

    internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
    {
        using (var scope = CompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();
            return await mediator.Send(command);
        }
    }
}
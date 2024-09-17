using AdsManagementAPI.Modules.Auth.Application.Contracts;
using MediatR;

namespace AdsManagementAPI.Modules.Auth.Application.Configuration.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
}
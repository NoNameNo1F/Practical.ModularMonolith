using AdsManagementAPI.BuildingBlocks.Infrastructure.Repositories;
using AdsManagementAPI.Modules.Auth.Application.Configuration.Commands;
using AdsManagementAPI.Modules.Auth.Application.Contracts;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Configuration.Processing;

//Without Result Command
internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T>
    where T : ICommand
{
    private readonly ICommandHandler<T> _command;
    
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerDecorator(
        ICommandHandler<T> command,
        IUnitOfWork unitOfWork)
    {
        _command = command;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(T command, CancellationToken cancellationToken)
    {
        await this._command.Handle(command, cancellationToken);
        await this._unitOfWork.CommitAsync(cancellationToken);
    }
}

//With Result Command
internal class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult>
    where T : ICommand<TResult>
{
    private readonly ICommandHandler<T, TResult> _command;

    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerWithResultDecorator(
        ICommandHandler<T, TResult> command,
        IUnitOfWork unitOfWork)
    {
        _command = command;
        _unitOfWork = unitOfWork;
    }

    public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
    {
        var result = await this._command.Handle(command, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        return result;
    }
}

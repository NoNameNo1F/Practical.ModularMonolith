using AdsManagementAPI.BuildingBlocks.Application;
using AdsManagementAPI.Modules.Auth.Application.Configuration.Commands;
using AdsManagementAPI.Modules.Auth.Application.Contracts;
using FluentValidation;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Configuration.Processing;

internal class ValidatorCommandHandlerDecorator<T> : ICommandHandler<T>
    where T : ICommand
{
    private readonly IList<IValidator<T>> _validators;

    private readonly ICommandHandler<T> _command;

    public ValidatorCommandHandlerDecorator(
        IList<IValidator<T>> validators,
        ICommandHandler<T> command)
    {
        this._validators = validators;
        this._command = command;
    }
    
    public async Task Handle(T command, CancellationToken cancellationToken)
    {
        var errors = _validators
            .Select(v => v.Validate(command))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();

        if (errors.Any())
        {
            throw new InvalidCommandException(
                errors.Select(x => x.ErrorMessage).ToList());
        }

        await _command.Handle(command, cancellationToken);
    }
}

internal class ValidationCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult>
    where T : ICommand<TResult>
{
    private readonly IList<IValidator<T>> _validators;

    private readonly ICommandHandler<T, TResult> _command;

    public ValidationCommandHandlerWithResultDecorator(
        IList<IValidator<T>> validators,
        ICommandHandler<T, TResult> command)
    {
        _validators = validators;
        _command = command;
    }

    public Task<TResult> Handle(T command, CancellationToken cancellationToken)
    {
        var errors = _validators
            .Select(v => v.Validate(command))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();

        if (errors.Any())
        {
            throw new InvalidCommandException(
                errors.Select(x => x.ErrorMessage).ToList());
        }

        return _command.Handle(command, cancellationToken);
    }
}
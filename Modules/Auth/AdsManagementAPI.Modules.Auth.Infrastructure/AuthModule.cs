using AdsManagementAPI.Modules.Auth.Application.Contracts;
using MediatR;
using Autofac;

namespace AdsManagementAPI.Modules.Auth.Infrastructure;
public class AuthModule : IAuthModule
{
    public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
    {
        return await CommandsExecutor.Execute(command);
    }

    public Task ExecuteCommandAsync(ICommand command)
    {
        throw new NotImplementedException();
    }

    public Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        throw new NotImplementedException();
    }
}
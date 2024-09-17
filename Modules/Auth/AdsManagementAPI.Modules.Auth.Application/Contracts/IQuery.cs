using MediatR;

namespace AdsManagementAPI.Modules.Auth.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
    
}
using AdsManagementAPI.Modules.Auth.Application.Contracts;
using MediatR;

namespace AdsManagementAPI.Modules.Auth.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}
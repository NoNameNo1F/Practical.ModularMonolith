using System.Reflection;
using AdsManagementAPI.BuildingBlocks.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AdsManagementAPI.BuildingBlocks.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    //private readonly IDomainEventsDispatcher _domainEventsDispatcher;
    
    public UnitOfWork(
        DbContext context
        //IDomainEventsDispatcher domainEventDispatcher
    )
    {
        this._context = context;
        //this._domainEventsDispatcher = domainEventsDispatcher;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        // await this._domainEventsDispatcher.DispatchEventsAsync();
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
namespace AdsManagementAPI.BuildingBlocks.Infrastructure.Repositories;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
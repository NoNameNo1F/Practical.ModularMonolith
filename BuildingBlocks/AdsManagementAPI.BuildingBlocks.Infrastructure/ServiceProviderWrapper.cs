using Autofac;

namespace AdsManagementAPI.BuildingBlocks.Infrastructure;

public class ServiceProviderWrapper : IServiceProvider
{
    private readonly ILifetimeScope _lifetimeScope;

    public ServiceProviderWrapper(ILifetimeScope lifetimeScope)
    {
        this._lifetimeScope = lifetimeScope;
    }

    public object? GetService(Type serviceType) => this._lifetimeScope.ResolveOptional(serviceType);
}
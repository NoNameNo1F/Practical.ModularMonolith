using AdsManagementAPI.BuildingBlocks.Application.Events;
using AdsManagementAPI.BuildingBlocks.Infrastructure;
using AdsManagementAPI.BuildingBlocks.Infrastructure.Repositories;
using Autofac;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Configuration.Processing;

internal class ProcessingModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(Assemblies.Application)
            .AsClosedTypesOf(typeof(IDomainEventNotification<>))
            .InstancePerDependency()
            .FindConstructorsWith(new AllConstructorFinder());
    }
}
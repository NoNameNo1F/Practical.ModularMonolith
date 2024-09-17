using MediatR;

namespace AdsManagementAPI.BuildingBlocks.Domain.DomainEvents;

public interface IDomainEvent : INotification
{
    Guid Id { get; }
    
    DateTime CreatedAt { get; }
}
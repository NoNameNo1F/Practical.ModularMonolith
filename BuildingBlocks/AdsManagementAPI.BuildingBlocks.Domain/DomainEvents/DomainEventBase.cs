namespace AdsManagementAPI.BuildingBlocks.Domain.DomainEvents;

public class DomainEventBase : IDomainEvent
{
    public Guid Id { get; }
    
    public DateTime CreatedAt { get; }

    public DomainEventBase()
    {
        this.Id = Guid.NewGuid();
        this.CreatedAt = DateTime.UtcNow;
    }
}
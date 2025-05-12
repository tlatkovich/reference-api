using Equipment.Core.Interfaces;

namespace Equipment.Core.Common.Events;

public abstract class BaseIntegrationEvent : IDomainEvent, INotification
{
    public Guid EventId { get; init; } = Guid.NewGuid();

    public DateTimeOffset EventDate { get; init; } = DateTimeOffset.UtcNow;
}
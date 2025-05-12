namespace Equipment.Core.Interfaces;

public interface IDomainEvent
{
    Guid EventId { get; init; }
}
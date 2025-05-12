namespace Equipment.Core.Interfaces;

public interface IDomainEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}
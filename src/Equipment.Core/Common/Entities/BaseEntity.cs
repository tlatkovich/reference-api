using Equipment.Core.Interfaces;

namespace Equipment.Core.Common.Entities;

public abstract class BaseEntity<TId> : IDomainEntity
{
    public TId Id { get; init; } = default!;

    #region Domain Events

    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();

    #endregion
}
using Equipment.Core.Interfaces;

namespace Equipment.Infrastructure.Databases;

public class DomainEventsInterceptor(IPublisher publisher) : SaveChangesInterceptor
{
    private readonly IPublisher _publisher = publisher;

    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            await PublishAndClearEventsAsync(eventData.Context, cancellationToken);
        }

        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private async Task PublishAndClearEventsAsync(DbContext context, CancellationToken cancellationToken)
    {
        var entitiesWithDomainEvents = context.ChangeTracker
            .Entries<IDomainEntity>()
            .Select(e => e.Entity)
            .Where(e => e?.DomainEvents is not null && e.DomainEvents.Count > 0)
            .ToList();

        foreach (var entity in entitiesWithDomainEvents)
        {
            foreach (var domainEvent in entity.DomainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }
        }

        entitiesWithDomainEvents.ForEach(e => e.ClearDomainEvents());
    }
}

using Equipment.Core.Interfaces;

namespace Equipment.Infrastructure.Databases;

public class AuditedEntityInterceptor(ICurrentUserService currentUser) : SaveChangesInterceptor
{
    private readonly ICurrentUserService _currentUser = Guard.Against.Null(currentUser, nameof(currentUser));

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        AuditEntities(eventData);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        AuditEntities(eventData);

        return base.SavingChanges(eventData, result);
    }

    private void AuditEntities(DbContextEventData eventData)
    {
        var now = DateTime.UtcNow;

        var currentUser = _currentUser.UserId ?? "System";

        foreach (var entry in eventData.Context!.ChangeTracker.Entries<IAuditedEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = now;
                entry.Entity.CreatedBy = currentUser;
                entry.Entity.ModifiedDate = now;
                entry.Entity.ModifiedBy = currentUser;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedDate = now;
                entry.Entity.ModifiedBy = currentUser;
            }
        }
    }
}

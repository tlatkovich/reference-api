namespace Equipment.Core.Interfaces;

// This is the base interface for read-only repositories in the application.
// It inherits from IReadRepositoryBase, which provides basic read operations.
// The IReadRepository interface is used to define a contract for repositories that work with aggregate roots.
// An aggregate root is an entity that is the main entry point for a group of related entities.
// In this case, we are using IAggregateRoot as a marker interface to indicate that the entity is an aggregate root.
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}

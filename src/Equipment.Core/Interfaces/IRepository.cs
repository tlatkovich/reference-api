namespace Equipment.Core.Interfaces;

// This is the base repository interface for all repositories in the application. It is generic and can be used with any entity type.
// It inherits from IRepositoryBase, which provides basic CRUD operations.
// The IRepository interface is used to define a contract for repositories that work with aggregate roots.
// An aggregate root is an entity that is the main entry point for a group of related entities.
// In this case, we are using IAggregateRoot as a marker interface to indicate that the entity is an aggregate root.
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}

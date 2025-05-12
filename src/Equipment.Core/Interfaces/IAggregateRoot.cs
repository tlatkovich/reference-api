namespace Equipment.Core.Interfaces;

// This is a marker interface for aggregate root entities in the domain model.
// It is used to indicate that an entity is an aggregate root and can be managed by a repository.
// Repositories will only work with aggregate roots, not their children.
// This interface does not contain any members or methods; it serves as a marker only.
public interface IAggregateRoot { }

using Equipment.Core.Interfaces;

namespace Equipment.Infrastructure.Databases.EquipmentDb.Repositories;

public class EquipmentEfRepository<T>(EquipmentDbContext dbContext) : RepositoryBase<T>(dbContext), IRepository<T> where T : class, IAggregateRoot
{
}

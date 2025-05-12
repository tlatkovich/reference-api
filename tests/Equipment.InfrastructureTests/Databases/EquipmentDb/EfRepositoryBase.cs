using Equipment.Core.Interfaces;
using Equipment.Infrastructure.Databases.EquipmentDb;
using Equipment.Infrastructure.Databases.EquipmentDb.Repositories;

namespace Equipment.InfrastructureTests.Databases.EquipmentDb;

[Collection("Sequential")]
public abstract class EfRepositoryBase(SqlServerFixture fixture) : IClassFixture<SqlServerFixture>
{
    protected EquipmentDbContext _dbContext = new(fixture.DbOptions);
    public Mock<IPublisher> PublisherMock = fixture.PublisherMock;

    protected EquipmentEfRepository<T> GetRepository<T>() where T : class, IAggregateRoot
    {
        return new EquipmentEfRepository<T>(_dbContext);
    }
}


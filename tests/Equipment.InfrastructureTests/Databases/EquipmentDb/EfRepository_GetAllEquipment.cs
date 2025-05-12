using Equipment.Core.Domain.EquipmentAggregate.Specifications;
using Equipment.Infrastructure.Databases.EquipmentDb.Repositories;
using Equipment.InfrastructureTests.Common;

namespace Equipment.InfrastructureTests.Databases.EquipmentDb;

public class EfRepository_GetAllEquipment : EfRepositoryBase
{
    private readonly EquipmentEfRepository<Core.Domain.EquipmentAggregate.Equipment> _equipmentRepository;

    public EfRepository_GetAllEquipment(SqlServerFixture fixture) : base(fixture)
    {
        _equipmentRepository = GetRepository<Core.Domain.EquipmentAggregate.Equipment>();
    }

    [Fact]
    public async Task GetAllEquipment_ShouldReturnEquipment()
    {
        var equipment = EquipmentBuilder.Build();

        await _equipmentRepository.AddAsync(equipment);

        var getAllEquipmentSpec = new GetAllEquipmentSpec();

        var list = await _equipmentRepository.ListAsync(getAllEquipmentSpec);
        list.Count.ShouldBe(1);
    }
}

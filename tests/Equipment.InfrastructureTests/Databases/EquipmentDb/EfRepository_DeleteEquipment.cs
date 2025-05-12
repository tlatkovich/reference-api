using Equipment.Core.Domain.EquipmentAggregate.Specifications;
using Equipment.Infrastructure.Databases.EquipmentDb.Repositories;
using Equipment.InfrastructureTests.Common;

namespace Equipment.InfrastructureTests.Databases.EquipmentDb;

public class EfRepository_DeleteEquipment : EfRepositoryBase
{
    private readonly EquipmentEfRepository<Core.Domain.EquipmentAggregate.Equipment> _equipmentRepository;

    public EfRepository_DeleteEquipment(SqlServerFixture fixture) : base(fixture)
    {
        _equipmentRepository = GetRepository<Core.Domain.EquipmentAggregate.Equipment>();
    }

    [Fact]
    public async Task DeleteEquipment_ShouldNotReturnEquipment()
    {
        var equipment = EquipmentBuilder.Build();

        await _equipmentRepository.AddAsync(equipment);

        var getAllEquipmentpec = new GetAllEquipmentSpec();

        var list = await _equipmentRepository.ListAsync(getAllEquipmentpec);
        list.Count.ShouldBe(1);

        var retrievedEquipment = list.First();

        await _equipmentRepository.DeleteAsync(retrievedEquipment);

        list = await _equipmentRepository.ListAsync(getAllEquipmentpec);
        list.Count.ShouldBe(0);
    }
}

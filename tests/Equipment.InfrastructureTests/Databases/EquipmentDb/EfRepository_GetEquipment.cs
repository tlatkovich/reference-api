using Equipment.Core.Domain.EquipmentAggregate.Specifications;
using Equipment.Infrastructure.Databases.EquipmentDb.Repositories;
using Equipment.InfrastructureTests.Common;

namespace Equipment.InfrastructureTests.Databases.EquipmentDb;

public class EfRepository_GetEquipment : EfRepositoryBase
{
    private readonly EquipmentEfRepository<Core.Domain.EquipmentAggregate.Equipment> _equipmentRepository;

    public EfRepository_GetEquipment(SqlServerFixture fixture) : base(fixture)
    {
        _equipmentRepository = GetRepository<Core.Domain.EquipmentAggregate.Equipment>();
    }

    [Fact]
    public async Task GetEquipment_ShouldReturnEquipment()
    {
        var equipment = EquipmentBuilder.Build();

        await _equipmentRepository.AddAsync(equipment);

        var getEquipmentSpec = new GetEquipmentByIdSpec(equipment.Id, false);

        var retrievedEquipment = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentSpec)
            ?? throw new InvalidOperationException("Equipment not found");

        retrievedEquipment.Id.ShouldBe(equipment.Id);
        retrievedEquipment.EquipmentNumber.ShouldBe(equipment.EquipmentNumber);
        retrievedEquipment.SerialNumber.ShouldBe(equipment.SerialNumber);
        retrievedEquipment.Status.ShouldBe(equipment.Status);
        retrievedEquipment.Make.ShouldBe(equipment.Make);
        retrievedEquipment.Model.ShouldBe(equipment.Model);
        retrievedEquipment.Year.ShouldBe(equipment.Year);
    }
}

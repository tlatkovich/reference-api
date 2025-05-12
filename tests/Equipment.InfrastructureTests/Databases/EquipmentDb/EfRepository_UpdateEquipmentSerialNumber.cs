using Equipment.Core.Domain.EquipmentAggregate.Specifications;
using Equipment.Core.Domain.ValueObjects;
using Equipment.Infrastructure.Databases.EquipmentDb.Repositories;
using Equipment.InfrastructureTests.Common;

namespace Equipment.InfrastructureTests.Databases.EquipmentDb;

public class EfRepository_UpdateEquipmenterialNumber : EfRepositoryBase
{
    private readonly EquipmentEfRepository<Core.Domain.EquipmentAggregate.Equipment> _equipmentRepository;

    public EfRepository_UpdateEquipmenterialNumber(SqlServerFixture fixture) : base(fixture)
    {
        _equipmentRepository = GetRepository<Core.Domain.EquipmentAggregate.Equipment>();
    }

    [Fact]
    public async Task UpdateEquipmenterialNumber_ShouldUpdateEquipmenterialNumber()
    {
        var equipment = EquipmentBuilder.Build();

        await _equipmentRepository.AddAsync(equipment);

        var getEquipmentWithAttachmentSpec = new GetEquipmentByIdSpec(equipment.Id, true);

        var retrievedEquipment = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentWithAttachmentSpec)
            ?? throw new InvalidOperationException("Equipment not found");

        retrievedEquipment.SerialNumber.ShouldBe(equipment.SerialNumber);

        var newEquipmenterialNumber = new SerialNumber("Serial Number");

        equipment.UpdateSerialNumber(newEquipmenterialNumber);

        await _equipmentRepository.UpdateAsync(equipment);

        var updatedEquipment = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentWithAttachmentSpec)
            ?? throw new InvalidOperationException("Equipment not found");

        updatedEquipment.SerialNumber.ShouldBe(newEquipmenterialNumber);
    }
}

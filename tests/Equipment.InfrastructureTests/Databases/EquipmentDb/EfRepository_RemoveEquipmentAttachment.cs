using Equipment.Core.Domain.EquipmentAggregate.Specifications;
using Equipment.Infrastructure.Databases.EquipmentDb.Repositories;
using Equipment.InfrastructureTests.Common;

namespace Equipment.InfrastructureTests.Databases.EquipmentDb;

public class EfRepository_RemoveEquipmentAttachment : EfRepositoryBase
{
    private readonly EquipmentEfRepository<Core.Domain.EquipmentAggregate.Equipment> _equipmentRepository;

    public EfRepository_RemoveEquipmentAttachment(SqlServerFixture fixture) : base(fixture)
    {
        _equipmentRepository = GetRepository<Core.Domain.EquipmentAggregate.Equipment>();
    }

    [Fact]
    public async Task RemoveEquipmentAttachment_ShouldRemoveAttachment()
    {
        var equipment = await AddEquipmentWithAttachment();

        var getEquipmentWithAttachmentSpec = new GetEquipmentByIdSpec(equipment.Id, true);

        var equipmentWithAttachment = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentWithAttachmentSpec)
            ?? throw new InvalidOperationException("Equipment not found");

        equipmentWithAttachment.Attachments.Count.ShouldBe(1);

        var attachmentToRemove = equipmentWithAttachment.Attachments.First();

        equipment.RemoveAttachment(attachmentToRemove);

        await _equipmentRepository.UpdateAsync(equipment);

        var updatedEquipment = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentWithAttachmentSpec)
            ?? throw new InvalidOperationException("Equipment not found");

        updatedEquipment.Attachments.Count.ShouldBe(0);
    }

    private async Task<Core.Domain.EquipmentAggregate.Equipment> AddEquipmentWithAttachment()
    {
        var equipment = EquipmentBuilder.Build();

        await _equipmentRepository.AddAsync(equipment);

        var equipmentToAttach = EquipmentBuilder.BuildToAttach();

        await _equipmentRepository.AddAsync(equipmentToAttach);

        equipment.AddAttachment(equipmentToAttach);

        await _equipmentRepository.UpdateAsync(equipment);

        return equipment;
    }
}

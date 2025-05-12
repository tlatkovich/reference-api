using Equipment.Core.Domain.EquipmentAggregate.Events;
using Equipment.Core.Domain.EquipmentAggregate.Specifications;
using Equipment.Infrastructure.Databases.EquipmentDb.Repositories;
using Equipment.InfrastructureTests.Common;

namespace Equipment.InfrastructureTests.Databases.EquipmentDb;

public class EfRepository_AddEquipment : EfRepositoryBase
{
    private readonly EquipmentEfRepository<Core.Domain.EquipmentAggregate.Equipment> _equipmentRepository;

    public EfRepository_AddEquipment(SqlServerFixture fixture) : base(fixture)
    {
        _equipmentRepository = GetRepository<Core.Domain.EquipmentAggregate.Equipment>();
    }

    [Fact]
    public async Task AddEquipment_ShouldReturnEquipment()
    {
        var equipment = EquipmentBuilder.Build();

        await _equipmentRepository.AddAsync(equipment);

        var getEquipmentSpec = new GetEquipmentByIdSpec(equipment.Id, false);

        var retrievedEquipment = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentSpec)
            ?? throw new InvalidOperationException("Equipment not found");

        retrievedEquipment.Id.ShouldBe(equipment.Id);
        retrievedEquipment.EquipmentNumber.ShouldBe(equipment.EquipmentNumber);
        retrievedEquipment.IsAttachment.ShouldBeFalse();
        retrievedEquipment.Status.ShouldBe(equipment.Status);
        retrievedEquipment.SerialNumber.ShouldBe(equipment.SerialNumber);
        retrievedEquipment.Make.ShouldBe(equipment.Make);
        retrievedEquipment.Model.ShouldBe(equipment.Model);
        retrievedEquipment.Year.ShouldBe(equipment.Year);

        PublisherMock.Verify(p => p.Publish(
            It.Is<object>(o => o is EquipmentCreatedEvent
                && ((EquipmentCreatedEvent)o).EquipmentId == retrievedEquipment.Id
            ),
            It.IsAny<CancellationToken>()
        ), Times.Once);
    }

    [Fact]
    public async Task AddEquipmentAsAttachment_ShouldReturnEquipment()
    {
        var equipment = EquipmentBuilder.BuildToAttach();

        await _equipmentRepository.AddAsync(equipment);

        var getEquipmentSpec = new GetEquipmentByIdSpec(equipment.Id, false);

        var retrievedEquipment = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentSpec)
            ?? throw new InvalidOperationException("Equipment not found");

        retrievedEquipment.Id.ShouldBe(equipment.Id);
        retrievedEquipment.EquipmentNumber.ShouldBe(equipment.EquipmentNumber);
        retrievedEquipment.IsAttachment.ShouldBeTrue();
        retrievedEquipment.Status.ShouldBe(equipment.Status);
        retrievedEquipment.SerialNumber.ShouldBe(equipment.SerialNumber);
        retrievedEquipment.Make.ShouldBe(equipment.Make);
        retrievedEquipment.Model.ShouldBe(equipment.Model);
        retrievedEquipment.Year.ShouldBe(equipment.Year);

        PublisherMock.Verify(p => p.Publish(
            It.Is<object>(o => o is EquipmentCreatedEvent
                && ((EquipmentCreatedEvent)o).EquipmentId == retrievedEquipment.Id
            ),
            It.IsAny<CancellationToken>()
        ), Times.Once);
    }
}

using Equipment.Core.Common.Events;
using Equipment.Core.Domain.ValueObjects;

namespace Equipment.Core.Domain.EquipmentAggregate.Events;

public class EquipmentCreatedEvent(Equipment equipment) : BaseDomainEvent
{
    public EquipmentId EquipmentId { get; init; } = equipment.Id;
}
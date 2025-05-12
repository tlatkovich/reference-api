using Equipment.Core.Common.Events;
using Equipment.Core.Domain.ValueObjects;

namespace Equipment.Core.Domain.EquipmentAggregate.Events;

public class EquipmenterialNumberChangedEvent(Equipment equipment) : BaseDomainEvent
{
    public EquipmentId EquipmentId { get; init; } = equipment.Id;
}
using Equipment.Core.Common.Events;
using Equipment.Core.Domain.ValueObjects;

namespace Equipment.Core.Domain.EquipmentAggregate.Events;

public class EquipmentAttachmentRemovedEvent(Equipment equipment, Attachment attachment) : BaseDomainEvent
{
    public EquipmentId EquipmentId { get; init; } = equipment.Id;
    public AttachmentId AttachmentId { get; init; } = attachment.Id;
}
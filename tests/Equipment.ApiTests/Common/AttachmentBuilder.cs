using Equipment.Core.Domain.EquipmentAggregate;
using Equipment.Core.Domain.ValueObjects;

namespace Equipment.ApiTests.Common;

public static class AttachmentBuilder
{
    public static readonly AttachmentId AttachmentId = new(Guid.NewGuid());
    public static readonly EquipmentNumber EquipmentNumber = new(EquipmentAggregateConstants.AttachmentEquipmentNumber);
    public static readonly string Make = new(EquipmentAggregateConstants.AttachmentEquipmentMake);
    public static readonly string Model = new(EquipmentAggregateConstants.AttachmentEquipmentModel);

    public static Attachment Build()
    {
        return new Attachment(
            AttachmentId,
            EquipmentNumber,
            Make,
            Model);
    }
}

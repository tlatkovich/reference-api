using Equipment.Core.Domain.ValueObjects;

namespace Equipment.Core.Domain.EquipmentAggregate.Specifications;

public class GetEquipmentForAttachmentByIdSpec : Specification<Equipment>, ISingleResultSpecification<Equipment>
{
    public GetEquipmentForAttachmentByIdSpec(EquipmentId id)
    {
        Query
            .Where(equipment => equipment.Id == id && equipment.IsAttachment == true);
    }
}

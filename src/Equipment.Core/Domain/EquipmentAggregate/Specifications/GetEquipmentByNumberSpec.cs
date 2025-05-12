using Equipment.Core.Domain.ValueObjects;

namespace Equipment.Core.Domain.EquipmentAggregate.Specifications;

public class GetEquipmentByNumberSpec : Specification<Equipment>, ISingleResultSpecification<Equipment>
{
    public GetEquipmentByNumberSpec(EquipmentNumber equipmentNumber, bool includeAttachments = true)
    {
        if (includeAttachments)
        {
            Query
                .Include(equipment => equipment.Attachments);
        }

        Query
            .Where(equipment => equipment.EquipmentNumber == equipmentNumber);
    }
}

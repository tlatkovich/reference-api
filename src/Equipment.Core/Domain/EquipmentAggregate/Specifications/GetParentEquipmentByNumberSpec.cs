using Equipment.Core.Domain.ValueObjects;

namespace Equipment.Core.Domain.EquipmentAggregate.Specifications;

public class GetParentEquipmentByNumberSpec : Specification<Equipment>, ISingleResultSpecification<Equipment>
{
    public GetParentEquipmentByNumberSpec(EquipmentNumber equipmentNumber)
    {
        Query
            .Include(equipment => equipment.Attachments);

        Query
            .Where(equipment => equipment.Attachments.Any(a => a.EquipmentNumber == equipmentNumber));
    }
}

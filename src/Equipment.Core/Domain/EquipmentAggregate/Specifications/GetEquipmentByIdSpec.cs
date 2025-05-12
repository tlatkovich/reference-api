using Equipment.Core.Domain.ValueObjects;

namespace Equipment.Core.Domain.EquipmentAggregate.Specifications;

public class GetEquipmentByIdSpec : Specification<Equipment>, ISingleResultSpecification<Equipment>
{
    public GetEquipmentByIdSpec(EquipmentId id, bool includeAttachments = true)
    {
        if (includeAttachments)
        {
            Query
                .Include(equipment => equipment.Attachments);
        }

        Query
            .Where(equipment => equipment.Id == id);
    }
}

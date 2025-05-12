namespace Equipment.Core.Domain.EquipmentAggregate.Specifications;

public class GetAllEquipmentSpec : Specification<Equipment>
{
    public GetAllEquipmentSpec()
    {
        Query
            .OrderBy(equipment => equipment.EquipmentNumber);
    }
}

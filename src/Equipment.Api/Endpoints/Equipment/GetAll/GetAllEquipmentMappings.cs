namespace Equipment.Api.Endpoints.Equipment.GetAll;

public static class GetAllEquipmentMappings
{
    public static GetAllEquipmentResponse ToGetAllEquipmentResponse(this IEnumerable<Core.Domain.EquipmentAggregate.Equipment> equipment)
    {
        return new GetAllEquipmentResponse
        {
            Equipment = equipment.Select(e => new EquipmentResponse
            {
                Id = e.Id.Value,
                EquipmentNumber = e.EquipmentNumber.Value,
                IsAttachment = e.IsAttachment,
                Status = e.Status,
                SerialNumber = e.SerialNumber.Value,
                Make = e.Make,
                Model = e.Model,
                Year = e.Year
            })
        };
    }
}
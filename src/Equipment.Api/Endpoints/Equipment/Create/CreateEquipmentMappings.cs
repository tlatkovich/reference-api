using Equipment.Core.Domain.ValueObjects;

namespace Equipment.Api.Endpoints.Equipment.Create;

public static class CreateEquipmentMappings
{
    public static Core.Domain.EquipmentAggregate.Equipment ToEquipment(this CreateEquipmentRequest request)
    {
        return Core.Domain.EquipmentAggregate.Equipment.Create(
            new EquipmentId(Guid.NewGuid()),
            request.IsAttachment,
            request.Status,
            new SerialNumber(request.SerialNumber),
            request.Make,
            request.Model,
            request.Year
        );
    }
    public static CreateEquipmentResponse ToCreateEquipmentResponse(this Core.Domain.EquipmentAggregate.Equipment equipment)
    {
        return new CreateEquipmentResponse
        {
            Id = equipment.Id.Value,
            EquipmentNumber = equipment.EquipmentNumber.Value,
            IsAttachment = equipment.IsAttachment,
            Status = equipment.Status,
            SerialNumber = equipment.SerialNumber.Value,
            Make = equipment.Make,
            Model = equipment.Model,
            Year = equipment.Year
        };
    }
}
namespace Equipment.Api.Endpoints.Equipment.Get;

public static class GetEquipmentMappings
{
    public static GetEquipmentResponse ToGetEquipmentResponse(this Core.Domain.EquipmentAggregate.Equipment equipment)
    {
        var equipmentResponse = new GetEquipmentResponse
        {
            Id = equipment.Id.Value,
            EquipmentNumber = equipment.EquipmentNumber.Value,
            Status = equipment.Status,
            SerialNumber = equipment.SerialNumber.Value,
            Make = equipment.Make,
            Model = equipment.Model,
            Year = equipment.Year
        };

        foreach (var attachment in equipment.Attachments)
        {
            var attachmentResponse = new GetEquipmentAttachmentResponse
            {
                Id = attachment.Id.Value,
                EquipmentNumber = attachment.EquipmentNumber.Value,
                Make = attachment.Make,
                Model = attachment.Model
            };

            equipmentResponse.Attachments.Add(attachmentResponse);
        }

        return equipmentResponse;
    }
}

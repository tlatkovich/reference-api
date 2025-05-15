namespace Equipment.Api.Endpoints.Equipment.UpdateSerialNumber;

public static class UpdateSerialNumberMappings
{
    public static UpdateSerialNumberResponse ToUpdateSerialNumberResponse(this Core.Domain.EquipmentAggregate.Equipment equipment)
    {
        var equipmentResponse = new UpdateSerialNumberResponse
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
            var attachmentResponse = new UpdateSerialNumberAttachmentResponse
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

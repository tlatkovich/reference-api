namespace Equipment.Api.Endpoints.Equipment.AddAttachment;

public static class AddAttachmentMappings
{
    public static AddAttachmentResponse ToAddAttachmentResponse(this Core.Domain.EquipmentAggregate.Equipment equipment)
    {
        var equipmentResponse = new AddAttachmentResponse
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
            var attachmentResponse = new AddAttachmentAttachmentResponse
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

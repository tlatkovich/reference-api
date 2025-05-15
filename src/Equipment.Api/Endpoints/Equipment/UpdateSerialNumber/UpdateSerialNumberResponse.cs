using Equipment.Api.Endpoints.Equipment.Common;

namespace Equipment.Api.Endpoints.Equipment.UpdateSerialNumber;

public record UpdateSerialNumberResponse : BaseEquipmentResponse
{
    public IList<UpdateSerialNumberAttachmentResponse> Attachments { get; set; } = [];
}

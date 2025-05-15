using Equipment.Api.Endpoints.Equipment.Common;

namespace Equipment.Api.Endpoints.Equipment.Get;

public record GetEquipmentResponse : BaseEquipmentResponse
{
    public IList<GetEquipmentAttachmentResponse> Attachments { get; set; } = [];
}

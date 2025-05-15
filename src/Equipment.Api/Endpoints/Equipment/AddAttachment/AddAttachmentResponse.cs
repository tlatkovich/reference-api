using Equipment.Api.Endpoints.Equipment.Common;

namespace Equipment.Api.Endpoints.Equipment.AddAttachment;

public record AddAttachmentResponse : BaseEquipmentResponse
{
    public IList<AddAttachmentAttachmentResponse> Attachments { get; set; } = [];
}

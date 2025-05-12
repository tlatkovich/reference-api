using Equipment.Api.Common.Requests;

namespace Equipment.Api.Endpoints.Equipment.AddAttachment;

public record AddAttachmentRequest : RequestWithGuidId
{
    public const string ROUTE = "/equipment/{id}/attachments";

    public Guid EquipmentId { get; init; }
}

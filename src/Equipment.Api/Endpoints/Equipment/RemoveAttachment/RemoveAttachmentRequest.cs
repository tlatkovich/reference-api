using Equipment.Api.Common.Requests;

namespace Equipment.Api.Endpoints.Equipment.RemoveAttachment;

public record RemoveAttachmentRequest : RequestWithGuidId
{
    public const string ROUTE = "/equipment/{id}/attachments/{attachmentId}";

    public Guid AttachmentId { get; init; }
}

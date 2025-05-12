using Equipment.Core.Domain.ValueObjects;

namespace Equipment.Core.Domain.EquipmentAggregate.Guards;

public static class EquipmentGuardExtensions
{
    public static void InvalidEquipmentForAttachment(this IGuardClause guardClause, Equipment equipment)
    {
        if (equipment.IsAttachment)
        {
            throw new ArgumentException($"{equipment.EquipmentNumber.Value} is an attachment. Attachments cannot have attachments.");
        }
    }
    public static void InvalidEquipmentToAttach(this IGuardClause guardClause, Equipment equipment, string parameterName)
    {
        if (!equipment.IsAttachment)
        {
            throw new ArgumentException($"{equipment.EquipmentNumber.Value} is not an attachment.", parameterName);
        }
    }
    public static void DuplicateAttachment(this IGuardClause guardClause, IEnumerable<Attachment> existingAttachments, Equipment equipment, string parameterName)
    {
        if (existingAttachments.Any(a => a.EquipmentNumber == equipment.EquipmentNumber))
        {
            throw new ArgumentException($"{equipment.EquipmentNumber.Value} is already attached.", parameterName);
        }
    }
    public static Attachment AttachmentNotFound(this IGuardClause guardClause, IEnumerable<Attachment> existingAttachments, AttachmentId attachmentId, string parameterName)
    {
        var attachment = existingAttachments.SingleOrDefault(a => a.Id == attachmentId) ?? throw new ArgumentException("Attachment not found.", parameterName);
        return attachment;
    }
}
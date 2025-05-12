using Equipment.Core.Common.Entities;
using Equipment.Core.Domain.EquipmentAggregate.Events;
using Equipment.Core.Domain.EquipmentAggregate.Guards;
using Equipment.Core.Domain.ValueObjects;
using Equipment.Core.Interfaces;

namespace Equipment.Core.Domain.EquipmentAggregate;

public class Equipment : BaseAuditedEntity<EquipmentId>, IAggregateRoot
{
    public EquipmentNumber EquipmentNumber { get; private set; } = default!;
    public bool IsAttachment { get; private set; } = default!;
    public string Status { get; private set; } = default!;
    public SerialNumber SerialNumber { get; private set; } = default!;
    public string Make { get; private set; } = default!;
    public string Model { get; private set; } = default!;
    public int Year { get; private set; } = default!;
    public IReadOnlyCollection<Attachment> Attachments => _attachments.AsReadOnly();
    private readonly List<Attachment> _attachments = [];

    #region EF Navigation Properties
    private Equipment() { } // EF Core requires a parameterless constructor for materialization
    #endregion

    private Equipment(
        EquipmentId id,
        bool isAttachment,
        string status,
        SerialNumber serialNumber,
        string make,
        string model,
        int year)
    {
        Id = Guard.Against.Null(id, nameof(id));
        IsAttachment = isAttachment;
        Status = Guard.Against.NullOrWhiteSpace(status, nameof(Status));
        SerialNumber = Guard.Against.Null(serialNumber, nameof(serialNumber));
        Make = Guard.Against.NullOrWhiteSpace(make, nameof(make));
        Model = Guard.Against.NullOrWhiteSpace(model, nameof(model));
        Year = Guard.Against.NegativeOrZero(year, nameof(year));
    }

    public static Equipment Create(
        EquipmentId id,
        bool isAttachment,
        string status,
        SerialNumber serialNumber,
        string make,
        string model,
        int year)
    {
        var equipment = new Equipment(id, isAttachment, status, serialNumber, make, model, year);
        equipment.AddDomainEvent(new EquipmentCreatedEvent(equipment));
        return equipment;
    }

    public void UpdateSerialNumber(SerialNumber serialNumber)
    {
        SerialNumber = Guard.Against.Null(serialNumber, nameof(serialNumber));
        AddDomainEvent(new EquipmenterialNumberChangedEvent(this));
    }

    public void AddAttachment(Equipment equipment)
    {
        Guard.Against.InvalidEquipmentForAttachment(this);
        Guard.Against.Null(equipment, nameof(equipment));
        Guard.Against.InvalidEquipmentToAttach(equipment, nameof(equipment));
        Guard.Against.DuplicateAttachment(_attachments, equipment, nameof(equipment));

        var attachment = new Attachment(
            new AttachmentId(Guid.NewGuid()),
            equipment.EquipmentNumber,
            equipment.Make,
            equipment.Model);

        _attachments.Add(attachment);
        AddDomainEvent(new EquipmentAttachmentAddedEvent(this, attachment));
    }

    public void RemoveAttachment(Attachment attachment)
    {
        Guard.Against.Null(attachment, nameof(attachment));
        Guard.Against.AttachmentNotFound(_attachments, attachment.Id, nameof(attachment));

        _attachments.Remove(attachment);
        AddDomainEvent(new EquipmentAttachmentRemovedEvent(this, attachment));
    }
}

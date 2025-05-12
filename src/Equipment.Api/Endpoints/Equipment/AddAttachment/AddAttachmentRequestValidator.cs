namespace Equipment.Api.Endpoints.Equipment.AddAttachment;

public class AddAttachmentRequestValidator : AbstractValidator<AddAttachmentRequest>
{
    public AddAttachmentRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.EquipmentId)
            .NotEmpty();
    }
}
namespace Equipment.Api.Endpoints.Equipment.RemoveAttachment;

public class RemoveAttachmentRequestValidator : AbstractValidator<RemoveAttachmentRequest>
{
    public RemoveAttachmentRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.AttachmentId)
            .NotEmpty();
    }
}
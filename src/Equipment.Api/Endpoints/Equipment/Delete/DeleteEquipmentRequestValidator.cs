namespace Equipment.Api.Endpoints.Equipment.Delete;

public class DeleteEquipmentRequestValidator : AbstractValidator<DeleteEquipmentRequest>
{
    public DeleteEquipmentRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
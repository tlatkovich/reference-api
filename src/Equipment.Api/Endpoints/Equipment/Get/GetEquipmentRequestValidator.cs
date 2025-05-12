namespace Equipment.Api.Endpoints.Equipment.Get;

public class GetEquipmentRequestValidator : AbstractValidator<GetEquipmentRequest>
{
    public GetEquipmentRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
namespace Equipment.Api.Endpoints.Equipment.UpdateSerialNumber;

public class UpdateSerialNumberRequestValidator : AbstractValidator<UpdateSerialNumberRequest>
{
    public UpdateSerialNumberRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.SerialNumber)
            .NotEmpty()
            .MaximumLength(100);
    }
}

using Equipment.Api.Common.Requests;

namespace Equipment.Api.Endpoints.Equipment.UpdateSerialNumber;

public record UpdateSerialNumberRequest : RequestWithGuidId
{
    public const string ROUTE = "/equipment/{id}/serialnumber";

    public string SerialNumber { get; init; } = default!;
}

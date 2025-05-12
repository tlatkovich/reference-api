using Equipment.Api.Common.Requests;

namespace Equipment.Api.Endpoints.Equipment.GetAll;

public record GetAllEquipmentRequest : BaseRequest
{
    public const string ROUTE = "/equipment";
}

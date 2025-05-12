using Equipment.Api.Common.Responses;

namespace Equipment.Api.Endpoints.Equipment.GetAll;

public record GetAllEquipmentResponse : BaseResponse
{
    public IEnumerable<EquipmentResponse> Equipment { get; init; } = [];
}
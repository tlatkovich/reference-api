using Equipment.Api.Endpoints.Equipment.Create;
using Equipment.Core.Domain.ValueObjects;

namespace Equipment.ApiTests.Common;

public static class RequestBuilders
{
    public static readonly string Status = new(EquipmentAggregateConstants.EquipmentStatus);
    public static readonly SerialNumber SerialNumber = new(EquipmentAggregateConstants.EquipmentSerialNumber);
    public static readonly string Make = new(EquipmentAggregateConstants.EquipmentMake);
    public static readonly string Model = new(EquipmentAggregateConstants.EquipmentModel);
    public static readonly int Year = EquipmentAggregateConstants.EquipmentYear;

    public static CreateEquipmentRequest BuildCreateEquipmentRequest(bool isAttachment = false)
    {
        return new CreateEquipmentRequest
        {
            IsAttachment = isAttachment,
            Status = Status,
            SerialNumber = SerialNumber.Value,
            Make = Make,
            Model = Model,
            Year = Year
        };
    }
}

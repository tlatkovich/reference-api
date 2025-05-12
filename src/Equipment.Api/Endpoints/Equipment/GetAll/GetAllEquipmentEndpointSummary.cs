namespace Equipment.Api.Endpoints.Equipment.GetAll;

public class GetAllEquipmentEndpointSummary : Summary<GetAllEquipmentEndpoint>
{
    public GetAllEquipmentEndpointSummary()
    {
        Summary = "Returns all the equipment";
        Description = "Returns all the equipment in the system";
    }
}

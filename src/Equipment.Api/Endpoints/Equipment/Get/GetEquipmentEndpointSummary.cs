namespace Equipment.Api.Endpoints.Equipment.Get;

public class GetEquipmentEndpointSummary : Summary<GetEquipmentEndpoint>
{
    public GetEquipmentEndpointSummary()
    {
        Summary = "Returns a single equipment by id";
        Description = "Returns a single equipment by id";
    }
}

namespace Equipment.Api.Endpoints.Equipment.Delete;

public class DeleteEquipmentEndpointSummary : Summary<DeleteEquipmentEndpoint>
{
    public DeleteEquipmentEndpointSummary()
    {
        Summary = "Deleted an equipment from the system";
        Description = "Deleted an equipment from the system";
    }
}

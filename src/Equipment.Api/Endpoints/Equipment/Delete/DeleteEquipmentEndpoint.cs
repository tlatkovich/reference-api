using Equipment.Core.Domain.EquipmentAggregate.Specifications;
using Equipment.Core.Domain.ValueObjects;
using Equipment.Core.Interfaces;
using Equipment.Api.Common;

namespace Equipment.Api.Endpoints.Equipment.Delete;

public class DeleteEquipmentEndpoint(
    HybridCache hybridCache,
    IRepository<Core.Domain.EquipmentAggregate.Equipment> equipmentRepository)
    : Endpoint<DeleteEquipmentRequest>
{
    private readonly HybridCache _cache = hybridCache;
    private readonly IRepository<Core.Domain.EquipmentAggregate.Equipment> _equipmentRepository = equipmentRepository;

    public override void Configure()
    {
        Delete(DeleteEquipmentRequest.ROUTE);
        AuthSchemes(WebApiConstants.JWT_BEARER_SCHEME_AAD);
    }

    public override async Task HandleAsync(DeleteEquipmentRequest deleteEquipmentRequest, CancellationToken cancellationToken)
    {
        var equipmentId = new EquipmentId(deleteEquipmentRequest.Id);
        var cacheKey = $"Equipment:{equipmentId.Value}";

        var getEquipmentSpec = new GetEquipmentByIdSpec(equipmentId, false);

        var equipment = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentSpec, cancellationToken);
        if (equipment is null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        await _equipmentRepository.DeleteAsync(equipment, cancellationToken);

        await _cache.RemoveAsync(cacheKey, cancellationToken);

        await SendNoContentAsync(cancellationToken);
    }
}

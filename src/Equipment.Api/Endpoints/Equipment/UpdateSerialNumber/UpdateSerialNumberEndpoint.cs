using Equipment.Core.Domain.EquipmentAggregate.Specifications;
using Equipment.Core.Domain.ValueObjects;
using Equipment.Core.Interfaces;
using Equipment.Api.Common;

namespace Equipment.Api.Endpoints.Equipment.UpdateSerialNumber;

public class UpdateSerialNumberEndpoint(
    HybridCache hybridCache,
    IRepository<Core.Domain.EquipmentAggregate.Equipment> equipmentRepository)
    : Endpoint<UpdateSerialNumberRequest>
{
    private readonly HybridCache _cache = hybridCache;
    private readonly IRepository<Core.Domain.EquipmentAggregate.Equipment> _equipmentRepository = equipmentRepository;

    public override void Configure()
    {
        Put(UpdateSerialNumberRequest.ROUTE);
        AuthSchemes(WebApiConstants.JWT_BEARER_SCHEME_AAD);
    }

    public override async Task HandleAsync(UpdateSerialNumberRequest updateSerialNumberRequest, CancellationToken cancellationToken)
    {
        var equipmentId = new EquipmentId(updateSerialNumberRequest.Id);
        var cacheKey = $"Equipment:{equipmentId.Value}";
        var cacheTags = new[] { "EquipmentAggregate" };

        var getEquipmentpec = new GetEquipmentByIdSpec(equipmentId, false);

        var equipment = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentpec, cancellationToken);
        if (equipment is null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        equipment.UpdateSerialNumber(new SerialNumber(updateSerialNumberRequest.SerialNumber));

        await _equipmentRepository.UpdateAsync(equipment, cancellationToken);

        var equipmentResponse = equipment.ToUpdateSerialNumberResponse();
        await _cache.SetAsync(
            cacheKey,
            equipmentResponse,
            tags: cacheTags,
            cancellationToken: cancellationToken
        );

        await SendNoContentAsync(cancellationToken);
    }
}

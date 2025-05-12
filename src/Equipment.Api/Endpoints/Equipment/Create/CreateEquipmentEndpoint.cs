using Equipment.Core.Domain.EquipmentAggregate.Specifications;
using Equipment.Core.Interfaces;
using Equipment.Api.Common;
using Equipment.Api.Endpoints.Equipment.Get;

namespace Equipment.Api.Endpoints.Equipment.Create;

public class CreateEquipmentEndpoint(
    HybridCache hybridCache,
    IRepository<Core.Domain.EquipmentAggregate.Equipment> equipmentRepository)
    : Endpoint<CreateEquipmentRequest, CreateEquipmentResponse>
{
    private readonly HybridCache _cache = hybridCache;
    private readonly IRepository<Core.Domain.EquipmentAggregate.Equipment> _equipmentRepository = equipmentRepository;

    public override void Configure()
    {
        Post(CreateEquipmentRequest.ROUTE);
        AuthSchemes(WebApiConstants.JWT_BEARER_SCHEME_AAD);
    }

    public override async Task HandleAsync(CreateEquipmentRequest createEquipmentRequest, CancellationToken cancellationToken)
    {
        var equipment = createEquipmentRequest.ToEquipment();
        var cacheTags = new[] { "EquipmentAggregate" };

        var getEquipmentSpec = new GetEquipmentByIdSpec(equipment.Id, false);

        var existingEquipment = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentSpec, cancellationToken);
        if (existingEquipment is not null)
        {
            AddError($"A equipment with id {equipment.Id} already exists");
        }

        ThrowIfAnyErrors();

        await _equipmentRepository.AddAsync(equipment, cancellationToken);

        var equipmentResponse = equipment.ToCreateEquipmentResponse();

        await _cache.RemoveByTagAsync(cacheTags, cancellationToken);

        await SendCreatedAtAsync<GetEquipmentEndpoint>(new { Id = equipment.Id.Value }, equipmentResponse, generateAbsoluteUrl: true, cancellation: cancellationToken);
    }
}

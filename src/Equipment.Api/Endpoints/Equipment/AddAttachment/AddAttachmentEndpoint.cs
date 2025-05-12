using Equipment.Core.Domain.EquipmentAggregate.Specifications;
using Equipment.Core.Domain.ValueObjects;
using Equipment.Core.Interfaces;
using Equipment.Api.Common;

namespace Equipment.Api.Endpoints.Equipment.AddAttachment;

public class AddAttachmentEndpoint(
    HybridCache hybridCache,
    IRepository<Core.Domain.EquipmentAggregate.Equipment> equipmentRepository)
    : Endpoint<AddAttachmentRequest>
{
    private readonly HybridCache _cache = hybridCache;
    private readonly IRepository<Core.Domain.EquipmentAggregate.Equipment> _equipmentRepository = equipmentRepository;

    public override void Configure()
    {
        Post(AddAttachmentRequest.ROUTE);
        AuthSchemes(WebApiConstants.JWT_BEARER_SCHEME_AAD);
    }

    public override async Task HandleAsync(AddAttachmentRequest addAttachmentRequest, CancellationToken cancellationToken)
    {
        var equipmentId = new EquipmentId(addAttachmentRequest.Id);
        var cacheKey = $"Equipment:{equipmentId.Value}";

        var getEquipmentSpec = new GetEquipmentByIdSpec(equipmentId);

        var equipment = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentSpec, cancellationToken);
        if (equipment is null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        var equipmentToAttachId = new EquipmentId(addAttachmentRequest.EquipmentId);

        var getEquipmentToAttachSpec = new GetEquipmentByIdSpec(equipmentToAttachId, false);

        var equipmentToAttach = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentToAttachSpec, cancellationToken);
        if (equipmentToAttach is null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        var getParentEquipmentByNumberSpec = new GetParentEquipmentByNumberSpec(equipmentToAttach.EquipmentNumber);

        var parentEquipment = await _equipmentRepository.SingleOrDefaultAsync(getParentEquipmentByNumberSpec, cancellationToken);
        if (parentEquipment is not null)
        {
            AddError($"Equipment {equipmentToAttach.EquipmentNumber} is already attached to {parentEquipment.EquipmentNumber}");
        }

        ThrowIfAnyErrors();

        equipment.AddAttachment(equipmentToAttach);

        await _equipmentRepository.UpdateAsync(equipment, cancellationToken);

        await _cache.RemoveAsync(cacheKey, cancellationToken);

        await SendNoContentAsync(cancellationToken);
    }
}

using Equipment.Core.Domain.EquipmentAggregate.Specifications;
using Equipment.Core.Domain.ValueObjects;
using Equipment.Core.Interfaces;
using Equipment.Api.Common;

namespace Equipment.Api.Endpoints.Equipment.RemoveAttachment;

public class RemoveAttachmentEndpoint(
    HybridCache hybridCache,
    IRepository<Core.Domain.EquipmentAggregate.Equipment> equipmentRepository)
    : Endpoint<RemoveAttachmentRequest>
{
    private readonly HybridCache _cache = hybridCache;
    private readonly IRepository<Core.Domain.EquipmentAggregate.Equipment> _equipmentRepository = equipmentRepository;

    public override void Configure()
    {
        Delete(RemoveAttachmentRequest.ROUTE);
        AuthSchemes(WebApiConstants.JWT_BEARER_SCHEME_AAD);
    }

    public override async Task HandleAsync(RemoveAttachmentRequest removeAttachmentRequest, CancellationToken cancellationToken)
    {
        var equipmentId = new EquipmentId(removeAttachmentRequest.Id);
        var cacheKey = $"Equipment:{equipmentId.Value}";

        var getEquipmentSpec = new GetEquipmentByIdSpec(equipmentId);

        var equipment = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentSpec, cancellationToken);
        if (equipment is null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        var attachment = equipment.Attachments.FirstOrDefault(a => a.Id.Value == removeAttachmentRequest.AttachmentId);
        if (attachment is null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        equipment.RemoveAttachment(attachment);

        await _equipmentRepository.UpdateAsync(equipment, cancellationToken);

        await _cache.RemoveAsync(cacheKey, cancellationToken);

        await SendNoContentAsync(cancellationToken);
    }
}

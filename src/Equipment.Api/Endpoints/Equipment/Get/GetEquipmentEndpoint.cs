using Equipment.Core.Domain.EquipmentAggregate.Specifications;
using Equipment.Core.Domain.ValueObjects;
using Equipment.Core.Interfaces;
using Equipment.Api.Common;

namespace Equipment.Api.Endpoints.Equipment.Get;

public class GetEquipmentEndpoint(
    HybridCache hybridCache,
    ILogger<GetEquipmentEndpoint> logger,
    IRepository<Core.Domain.EquipmentAggregate.Equipment> equipmentRepository)
    : Endpoint<GetEquipmentRequest, GetEquipmentResponse>
{
    private readonly HybridCache _cache = hybridCache;
    private readonly ILogger<GetEquipmentEndpoint> _logger = logger;
    private readonly IRepository<Core.Domain.EquipmentAggregate.Equipment> _equipmentRepository = equipmentRepository;

    public override void Configure()
    {
        Get(GetEquipmentRequest.ROUTE);
        AuthSchemes(WebApiConstants.JWT_BEARER_SCHEME_AAD);
    }

    public override async Task HandleAsync(GetEquipmentRequest getEquipmentRequest, CancellationToken cancellationToken)
    {
        var equipmentId = new EquipmentId(getEquipmentRequest.Id);
        var cacheKey = $"Equipment:{equipmentId.Value}";
        var cacheTags = new[] { "EquipmentAggregate" };

        var equipmentResponse = await _cache.GetOrCreateAsync(
            cacheKey,
            async (cancellationToken) =>
            {
                var getEquipmentSpec = new GetEquipmentByIdSpec(equipmentId);

                _logger.LogInformation("Fetching equipment with ID: {EquipmentId} from the repository", equipmentId.Value);

                var equipment = await _equipmentRepository.SingleOrDefaultAsync(getEquipmentSpec, cancellationToken);

                return equipment?.ToGetEquipmentResponse();
            },
            tags: cacheTags,
            cancellationToken: cancellationToken
        );

        if (equipmentResponse is null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        await SendOkAsync(equipmentResponse, cancellation: cancellationToken);
    }
}

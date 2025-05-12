using Equipment.Core.Domain.EquipmentAggregate.Specifications;
using Equipment.Core.Interfaces;
using Equipment.Api.Common;

namespace Equipment.Api.Endpoints.Equipment.GetAll;

public class GetAllEquipmentEndpoint(
    HybridCache hybridCache,
    ILogger<GetAllEquipmentEndpoint> logger,
    IRepository<Core.Domain.EquipmentAggregate.Equipment> equipmentRepository)
    : Endpoint<GetAllEquipmentRequest, GetAllEquipmentResponse>
{
    private readonly HybridCache _cache = hybridCache;
    private readonly ILogger<GetAllEquipmentEndpoint> _logger = logger;
    private readonly IRepository<Core.Domain.EquipmentAggregate.Equipment> _equipmentRepository = equipmentRepository;

    public override void Configure()
    {
        Get(GetAllEquipmentRequest.ROUTE);
        AuthSchemes(WebApiConstants.JWT_BEARER_SCHEME_AAD);
    }

    public override async Task HandleAsync(GetAllEquipmentRequest getAllEquipmentRequest, CancellationToken cancellationToken)
    {
        var cacheKey = $"Equipment:GetAll";
        var cacheTags = new[] { "EquipmentAggregate" };

        var equipmentResponse = await _cache.GetOrCreateAsync(
            cacheKey,
            async (cancellationToken) =>
            {
                var getAllEquipmentSpec = new GetAllEquipmentSpec();

                _logger.LogInformation("Fetching all equipment from the repository");

                var equipment = await _equipmentRepository.ListAsync(getAllEquipmentSpec, cancellationToken);

                return equipment.ToGetAllEquipmentResponse();
            },
            tags: cacheTags,
            cancellationToken: cancellationToken
        );

        await SendOkAsync(equipmentResponse, cancellation: cancellationToken);
    }
}

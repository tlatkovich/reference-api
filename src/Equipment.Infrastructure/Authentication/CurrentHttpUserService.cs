using Equipment.Core.Interfaces;

namespace Equipment.Infrastructure.Authentication;

public class CurrentHttpUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = Guard.Against.Null(httpContextAccessor, nameof(httpContextAccessor));

    public string? UserId
    {
        get
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}

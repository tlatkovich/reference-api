using Equipment.Core.Interfaces;

namespace Equipment.InfrastructureTests.Common;

public class CurrentTestUserService(string userId) : ICurrentUserService
{
    public string UserId { get; } = userId;
}

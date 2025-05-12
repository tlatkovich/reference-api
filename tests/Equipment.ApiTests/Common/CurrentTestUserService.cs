using Equipment.Core.Interfaces;

namespace Equipment.ApiTests.Common;

public class CurrentTestUserService(string userId) : ICurrentUserService
{
    public string UserId { get; } = userId;
}

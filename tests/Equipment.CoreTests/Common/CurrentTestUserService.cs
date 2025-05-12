using Equipment.Core.Interfaces;

namespace Equipment.CoreTests.Common;

public class CurrentTestUserService(string userId) : ICurrentUserService
{
    public string UserId { get; } = userId;
}

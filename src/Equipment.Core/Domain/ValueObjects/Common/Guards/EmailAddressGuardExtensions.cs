using System.Text.RegularExpressions;

namespace Ardalis.GuardClauses;

public static class EmailAddressGuardExtensions
{
    public static void InvalidEmailAddress(this IGuardClause guardClause, string emailAddress)
    {
        Regex EmailRegex = new("^[\\w!#$%&’*+/=?`{|}~^-]+(?:\\.[\\w!#$%&’*+/=?`{|}~^-]+)*@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        if (!EmailRegex.IsMatch(emailAddress))
        {
            var message = $"{emailAddress} is not a valid email address";
            throw new ValidationException(message,
            [
                new ValidationFailure(nameof(emailAddress), message)
            ]);
        }
    }
}
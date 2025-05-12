using System.Text.RegularExpressions;

namespace Ardalis.GuardClauses;

public static class PhoneNumberGuardExtensions
{
    public static void InvalidPhoneNumber(this IGuardClause guardClause, string phoneNumber)
    {
        Regex PhoneNumberRegex = new(@"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$", RegexOptions.Compiled);
        if (!PhoneNumberRegex.IsMatch(phoneNumber))
        {
            var message = $"{phoneNumber} is not a valid phone number";
            throw new ValidationException(message,
            [
                new ValidationFailure(nameof(phoneNumber), message)
            ]);
        }
    }
}
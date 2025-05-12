namespace Equipment.Api.Common.Requests;

public abstract record EmptyBaseRequest : BaseRequest
{
    // This abstract record is used for requests with no incoming data. 
    // This supports the requirement to have a CorrelationId in the request.
}

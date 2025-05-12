using Equipment.ApiTests.Common;
using Equipment.Api.Endpoints.Equipment.Create;

namespace Equipment.ApiTests.EquipmentEndpoints;

[Collection("Sequential")]
public class CreateEquipment(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateAuthenticatedClient();

    [Fact]
    public async Task CreateEquipment_ShouldReturnOkResponse()
    {
        var request = RequestBuilders.BuildCreateEquipmentRequest();

        var content = StringContentHelpers.FromModelAsJson(request);

        var response = await _client.PostAndDeserializeAsync<CreateEquipmentResponse>(CreateEquipmentRequest.ROUTE, content);

        response.ShouldNotBeNull();
        response.GetType().ShouldBe(typeof(CreateEquipmentResponse));
        response.Id.ShouldNotBe(Guid.Empty);
        response.EquipmentNumber.ShouldBeGreaterThan(0);
        response.IsAttachment.ShouldBe(request.IsAttachment);
        response.Status.ShouldBe(request.Status);
        response.SerialNumber.ShouldBe(request.SerialNumber);
        response.Make.ShouldBe(request.Make);
        response.Model.ShouldBe(request.Model);
        response.Year.ShouldBe(request.Year);
    }

    [Fact]
    public async Task CreateEquipmentAsAttachment_ShouldReturnOkResponse()
    {
        var request = RequestBuilders.BuildCreateEquipmentRequest();

        var content = StringContentHelpers.FromModelAsJson(request);

        var response = await _client.PostAndDeserializeAsync<CreateEquipmentResponse>(CreateEquipmentRequest.ROUTE, content);

        response.ShouldNotBeNull();
        response.GetType().ShouldBe(typeof(CreateEquipmentResponse));
        response.Id.ShouldNotBe(Guid.Empty);
        response.EquipmentNumber.ShouldBeGreaterThan(0);
        response.IsAttachment.ShouldBe(request.IsAttachment);
        response.Status.ShouldBe(request.Status);
        response.SerialNumber.ShouldBe(request.SerialNumber);
        response.Make.ShouldBe(request.Make);
        response.Model.ShouldBe(request.Model);
        response.Year.ShouldBe(request.Year);
    }
}

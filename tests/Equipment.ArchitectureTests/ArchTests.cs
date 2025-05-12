namespace Equipment.ArchitectureTests;

public class ClearnArchitectureTests
{
    private readonly Assembly DomainAssembly = typeof(Core.Domain.EquipmentAggregate.Equipment).Assembly;

    [Fact]
    public void Domain_Should_Not_Depend_On_Other_Layers()
    {
        var result = Types.InAssembly(DomainAssembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                "Equipment.Api",
                "Equipment.Infrastructure"
            ).GetResult();

        Assert.True(result.IsSuccessful, "Domain layer should not depend on Api or Infrastructure layers.");
    }

    [Fact]
    public void Infrastructure_Should_Not_Depend_On_Api_Layer()
    {
        var result = Types.InAssembly(DomainAssembly)
            .That()
            .ResideInNamespace("Equipment.Infrastructure")
            .ShouldNot()
            .HaveDependencyOn("Equipment.Api")
            .GetResult();

        Assert.True(result.IsSuccessful, "Infrastructure layer should not depend on Api layer.");
    }
}

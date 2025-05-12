using Equipment.Infrastructure.Databases;
using Equipment.Infrastructure.Databases.EquipmentDb;
using Equipment.InfrastructureTests.Common;

namespace Equipment.InfrastructureTests.Databases.EquipmentDb;

public class SqlServerFixture : IAsyncLifetime
{
    private readonly MsSqlContainer _sqlContainer;
    public Mock<IPublisher> PublisherMock = null!;
    public DbContextOptions<EquipmentDbContext> DbOptions { get; private set; } = null!;

    public SqlServerFixture()
    {
        _sqlContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithPassword("yourStrong(!)Password")
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _sqlContainer.StartAsync();

        var currentUserService = new CurrentTestUserService("Infrastructure Tester");
        var auditInterceptor = new AuditedEntityInterceptor(currentUserService);

        PublisherMock = new Mock<IPublisher>();
        var domainEventInterceptor = new DomainEventsInterceptor(PublisherMock.Object);

        var options = new DbContextOptionsBuilder<EquipmentDbContext>()
            .UseSqlServer(_sqlContainer.GetConnectionString())
            .AddInterceptors([auditInterceptor, domainEventInterceptor])
            .Options;

        using var context = new EquipmentDbContext(options);
        await context.Database.EnsureCreatedAsync();

        DbOptions = options;
    }

    public async Task DisposeAsync() => await _sqlContainer.DisposeAsync();
}

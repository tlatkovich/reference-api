using Equipment.Infrastructure.Databases.EquipmentDb;
using Equipment.ApiTests.Common;
using Equipment.Infrastructure.Databases;
using Microsoft.Extensions.Configuration;

namespace Equipment.ApiTests;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    private readonly MsSqlContainer _sqlContainer;
    public Mock<IPublisher> PublisherMock = null!;

    public CustomWebApplicationFactory()
    {
        _sqlContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithPassword("yourStrong(!)Password")
            .Build();
    }

    public HttpClient CreateAuthenticatedClient()
    {
        //Authenticate with Postman and then copy the token here
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<CustomWebApplicationFactory<TProgram>>()
            .Build();

        var token = configuration["ApiTestsToken"];
        if (string.IsNullOrEmpty(token))
        {
            throw new InvalidOperationException("Authenticate with Postman and then copy the token into user secrets.");
        }

        // Create client and attach Bearer token
        var client = CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return client;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");
        builder.ConfigureAppConfiguration((context, config) =>
        {
            // Add user secrets for test configuration
            config.AddUserSecrets<CustomWebApplicationFactory<TProgram>>(optional: true);
        });

        _sqlContainer.StartAsync().GetAwaiter().GetResult();

        builder.ConfigureServices(services =>
        {
            // Remove existing DbContext registration
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<EquipmentDbContext>));
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            // Create test user and audit interceptor
            var currentUserService = new CurrentTestUserService("Web API Tester");
            var auditInterceptor = new AuditedEntityInterceptor(currentUserService);

            PublisherMock = new Mock<IPublisher>();
            var domainEventInterceptor = new DomainEventsInterceptor(PublisherMock.Object);

            // Register DbContext using SQL Server from container
            services.AddDbContext<EquipmentDbContext>(options =>
            {
                options.UseSqlServer(_sqlContainer.GetConnectionString())
                       .AddInterceptors([auditInterceptor, domainEventInterceptor]);
            });

            // Remove existing HybridCache registration
            var cacheDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(HybridCache));
            if (cacheDescriptor is not null)
            {
                services.Remove(cacheDescriptor);
            }

            // Register mock HybridCache
            var hybridCacheMock = new Mock<HybridCache>();
            // Configure mock behavior as needed, e.g.:
            // hybridCacheMock.Setup(c => c.GetAsync(It.IsAny<string>(), ...)).ReturnsAsync(...);

            services.AddSingleton(hybridCacheMock.Object);
            // Build provider and apply schema
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();

            var db = scope.ServiceProvider.GetRequiredService<EquipmentDbContext>();
            db.Database.EnsureCreated();
        });
    }

    public override async ValueTask DisposeAsync()
    {
        await _sqlContainer.DisposeAsync();

        await base.DisposeAsync();
    }
}

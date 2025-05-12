namespace Equipment.Infrastructure.Databases.EquipmentDb;

public class EquipmentDbContextFactory : IDesignTimeDbContextFactory<EquipmentDbContext>
{
    public EquipmentDbContext CreateDbContext(string[] args)
    {
        var configBuilder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", true)
          .AddJsonFile("appsettings.Development.json", true)
          .AddEnvironmentVariables();

        var configuration = configBuilder.Build();

        var connectionString = configuration.GetConnectionString(DatabaseConstants.EQUIPMENT_DB_CONNECTION_STRING_NAME);

        var optionsBuilder = new DbContextOptionsBuilder<EquipmentDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new EquipmentDbContext(optionsBuilder.Options);
    }
}

using Equipment.Infrastructure.Databases.EquipmentDb;
using Equipment.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.AddSqlServerDbContext<EquipmentDbContext>("equipmentDb");

var host = builder.Build();
host.Run();
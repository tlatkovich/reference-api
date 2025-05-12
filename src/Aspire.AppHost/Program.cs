var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
    .WithLifetime(ContainerLifetime.Persistent);

var equipmentDb = sql.AddDatabase("equipmentDb");

builder.AddProject<Projects.Equipment_MigrationService>("migrations")
    .WithReference(equipmentDb).WaitFor(equipmentDb);

var redis = builder.AddRedis("redis");

builder.AddProject<Projects.Equipment_Api>("equipmentApi")
    .WithExternalHttpEndpoints()
    // .WithHttpHealthCheck("health")
    .WithReference(equipmentDb).WaitFor(equipmentDb)
    .WithReference(redis).WithParentRelationship(redis).WaitFor(redis);

builder.Build().Run();

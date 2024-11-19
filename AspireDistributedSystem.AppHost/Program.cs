var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireDistributedSystem_ApiService>("apiservice");

builder.AddProject<Projects.AspireDistributedSystem_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();

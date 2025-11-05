using System.Reflection;
using RailwayApp.Modules.Stations.Infrastructure;
using RailwayApp.Modules.Tickets.Infrastructure;
using RailwayApp.Modules.Trains.Infrastructure;
using RailwayApp.Shared.Application;

var builder = WebApplication.CreateBuilder(args);

// Add Application Modules Layers
Assembly[] moduleApplicationAssemblies = [
    RailwayApp.Modules.Stations.Application.AssemblyReference.Assembly,
    RailwayApp.Modules.Trains.Application.AssemblyReference.Assembly,
    RailwayApp.Modules.Tickets.Application.AssemblyReference.Assembly];

builder.Services.AddApplication(moduleApplicationAssemblies);

// Add Infrastructure Modules Layers
builder.Services.AddStationsModule(builder.Configuration);
builder.Services.AddTrainsModule(builder.Configuration);
builder.Services.AddTicketsModule(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

await app.RunAsync();
using Bank.Balance.Api.Application.Database;
using Bank.Balance.Api.Application.External.ServiceBusSender;
using Bank.Balance.Api.Application.Features.Process;
using Bank.Balance.Api.Application.Handlers;
using Bank.Balance.Api.External.ServiceBusReceive;
using Bank.Balance.Api.External.ServiceBusSender;
using Bank.Balance.Api.Persistence.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseService>(options =>
{
    options.UseSqlServer(builder.Configuration["BALANCESQLDBCONSTR"]);
});

builder.Services.AddScoped<IDatabaseService, DatabaseService>();
builder.Services.AddScoped<IProcessService, ProcessService>();
builder.Services.AddScoped<IServiceBusSenderService, ServiceBusSenderService>();

builder.Services.AddHostedService<ServiceBusReceiveService>();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(ProcessHandler).Assembly));

var app = builder.Build();

app.Run();


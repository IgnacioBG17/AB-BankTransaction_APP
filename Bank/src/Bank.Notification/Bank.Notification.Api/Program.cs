using Bank.Notification.Api.Application.Database;
using Bank.Notification.Api.Application.External.SendGridEmail;
using Bank.Notification.Api.Application.Features.Process;
using Bank.Notification.Api.Application.Handlers;
using Bank.Notification.Api.External.SendGridEmail;
using Bank.Notification.Api.External.ServiceBusReceive;
using Bank.Notification.Api.Persistence.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDatabaseService, DatabaseService>();
builder.Services.AddScoped<IProcessService, ProcessService>();

builder.Services.AddSingleton<ISendGridEmailService, SendGridEmailService>();

builder.Services.AddHostedService<ServiceBusReceiveService>();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(ProcessHandler).Assembly));

var app = builder.Build();

app.Run();


using MassTransit;
using MassTransit.Example.Worker;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMassTransit(configure => {
    configure.UsingRabbitMq((context, configuration) => {
        configuration.ConfigureEndpoints(context);
        configuration.ConcurrentMessageLimit = 1;
    });
    configure.AddConsumer<WorkConsumer>();
    configure.SetKebabCaseEndpointNameFormatter();
});

var app = builder.Build();

app.Run();

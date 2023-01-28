using MassTransit;
using MassTransit.Example.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMassTransit(configure => {
    configure.UsingRabbitMq();
    configure.AddRequestClient<Work>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapPost("/work", async (IRequestClient<Work> workRequestClient) => {
    return await workRequestClient.GetResponse<WorkDone>(new Work());
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

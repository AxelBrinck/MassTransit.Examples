using MassTransit.Example.Contracts;

namespace MassTransit.Example.Worker;

public sealed class WorkConsumer : IConsumer<Work>
{
    public async Task Consume(ConsumeContext<Work> context)
    {
        Console.WriteLine("Working...");
        await Task.Delay(2000);
        Console.WriteLine("Done.");

        await context.RespondAsync(new WorkDone());
    }
}
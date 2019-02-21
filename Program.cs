using MicroBatchFramework;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

// Entrypoint, create from the .NET Core Console App.
class Program
{
    static async Task Main(string[] args)
    {
        await new HostBuilder()
            .ConfigureLogging(x => x.AddConsole())
            .RunBatchEngine<MyFirstBatch>(args);
    }
}

// Batch definition.
public class MyFirstBatch : BatchBase // inherit BatchBase
{
    // allows void/Task return type, parameter allows all types(deserialized by Utf8Json and can pass by JSON string)
    public void Hello(string name, int repeat = 99)
    {
        for (int i = 0; i < repeat; i++)
        {
            this.Context.Logger.LogInformation($"Hello My Batch from {name}");
        }
    }
}

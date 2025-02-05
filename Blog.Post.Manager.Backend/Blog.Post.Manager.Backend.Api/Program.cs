using Microsoft.Extensions.Hosting;

namespace Blog.Post.Manager.Backend.Api;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                
            });

        await builder.RunConsoleAsync();
    }
}
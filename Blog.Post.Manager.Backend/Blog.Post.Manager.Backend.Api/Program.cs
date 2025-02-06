
using Blog.Post.Manager.Backend.Commands.Handlers;
using Blog.Post.Manager.Backend.Queries.Handlers;
using Blog.Post.Manager.Backend.Stores.Cosmos;
using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Post.Manager.Backend.Api;

/// <summary>
/// The program class.
/// </summary>
public static class Program
{
    /// <summary>
    /// Defines the entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuration for Cosmos DB NoSql Database
        var config = builder.Configuration;

        if (config["CosmosDb:Account"] is null 
                || config["CosmosDb:Key"] is null 
                    || config["CosmosDb:DatabaseName"] is null 
                        || config["CosmosDb:ContainerName"] is null) 
        {
            throw new NullReferenceException("Please provide CosmosDb:Account, CosmosDb:Key, CosmosDb:DatabaseName or CosmosDb:ContainerName in the appsettings.json");
        }

        var cosmosClient = new CosmosClient(config["CosmosDb:Account"], config["CosmosDb:Key"]);

        builder.Services.AddSingleton(cosmosClient);
        builder.Services.AddSingleton(sp =>
                new BlogPostStore(
                    cosmosClient,
                    config["CosmosDb:DatabaseName"],
                    config["CosmosDb:ContainerName"]
            ));

        // Configuration for MediatR
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(GetAllBlogPostQueryHandler).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(CreateBlogPostCommandHandler).Assembly);
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        var app = builder.Build();

        app.UseHttpsRedirection();
        app.MapControllers();

        await app.RunAsync();
    }
}
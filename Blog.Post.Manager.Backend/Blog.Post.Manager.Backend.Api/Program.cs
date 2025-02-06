
using Blog.Post.Manager.Backend.Commands.Handlers;
using Blog.Post.Manager.Backend.Cosmos.Model;
using Blog.Post.Manager.Backend.Queries.Handlers;
using Blog.Post.Manager.Backend.Stores.Abstraction;
using Blog.Post.Manager.Backend.Stores.Cosmos;
using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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

        // Bind settings
        builder.Services.Configure<CosmosDbSettings>(builder.Configuration.GetSection("CosmosDb"));

        // Register CosmosClient
        builder.Services.AddSingleton<CosmosClient>(serviceProvider =>
        {
            // Get the configuration from appsettings.json
            var settings = serviceProvider.GetRequiredService<IOptions<CosmosDbSettings>>().Value;
            return new CosmosClient(settings.AccountEndpoint, settings.Key);
        });

        // Register BlogPostStore
        builder.Services.AddTransient<IBlogPostStore, BlogPostStore>();

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
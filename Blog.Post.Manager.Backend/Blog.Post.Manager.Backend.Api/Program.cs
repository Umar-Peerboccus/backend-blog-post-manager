
using Blog.Post.Manager.Backend.Commands.Handlers;
using Blog.Post.Manager.Backend.Queries;
using Blog.Post.Manager.Backend.Queries.Handlers;
using Microsoft.AspNetCore.Builder;
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
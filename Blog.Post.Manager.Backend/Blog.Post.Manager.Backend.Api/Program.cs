
using Blog.Post.Manager.Backend.Commands.Handlers;
using Blog.Post.Manager.Backend.Cosmos.Model;
using Blog.Post.Manager.Backend.Mappings;
using Blog.Post.Manager.Backend.Models.Validators.Requests;
using Blog.Post.Manager.Backend.Queries.Handlers;
using Blog.Post.Manager.Backend.Stores.Abstraction;
using Blog.Post.Manager.Backend.Stores.Cosmos;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

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

        // Register AutoMapper with BusinessProfle.
        builder.Services.AddAutoMapper(typeof(BusinessProfile).Assembly);

        // Register FluentValidation
        builder.Services.AddValidatorsFromAssembly(typeof(CreateBlogPostRequestModelValidator).Assembly);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Blog Post Manager API",
                Version = "v1",
                Description = "Blog Post Manager Swagger API"
            });
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });
        
        var app = builder.Build();
        app.UseCors("AllowAll");
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog Post Manager API v1");
            c.RoutePrefix = string.Empty; // Set Swagger UI at root URL
            c.InjectStylesheet("/swagger-ui/custom.css"); // Helps debug UI loading issues
        });

        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.MapControllers();

        await app.RunAsync();
    }
}
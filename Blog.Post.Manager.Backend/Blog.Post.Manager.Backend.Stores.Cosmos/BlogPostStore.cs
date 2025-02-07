using Blog.Post.Manager.Backend.Cosmos.Model;
using Blog.Post.Manager.Backend.Stores.Abstraction;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Blog.Post.Manager.Backend.Stores.Cosmos;

/// <summary>
/// The store for blog posts.
/// </summary>
public class BlogPostStore : IBlogPostStore
{
    private readonly CosmosClient _cosmosClient;
    private readonly Container _container;
    private readonly ILogger<BlogPostStore> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlogPostStore"/> class.
    /// </summary>
    /// <param name="cosmosClient">The cosmos client.</param>
    /// <param name="settings">The database settings.</param>
    /// <param name="logger">The logger.</param>
    public BlogPostStore(CosmosClient cosmosClient, IOptions<CosmosDbSettings> settings, ILoggerFactory loggerFactory)
    {
        _cosmosClient = cosmosClient;
        _container = cosmosClient.GetContainer(settings.Value.DatabaseName, settings.Value.ContainerName);
        _logger = loggerFactory.CreateLogger<BlogPostStore>() ?? throw new ArgumentNullException(nameof(loggerFactory));
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateBlogPostAsync(string title, string content, string author, bool isPublished, bool isDeleted)
    {
        var blogPost = new BlogPost
        {
            Id = Guid.NewGuid(),
            Title = title,
            Content = content,
            Author = author,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsPublished = isPublished,
            IsDeleted = isDeleted
        };

        try
        {
            // Create the blog post in the container.
            await _container.CreateItemAsync(blogPost);
        }
        catch (Exception ex)
        {
            if (ex is CosmosException cosmosException)
            {
                _logger.LogError($"Received {cosmosException.StatusCode} ({cosmosException.Message}).");
            }
            else
            {
                _logger.LogError($"Exception {ex}.");
            }

            return Guid.Empty;
        }

        return blogPost.Id;
    }

    /// <inheritdoc/>
    public async Task<IList<BlogPost>> GetAllBlogPostAsync()
    {
        List<BlogPost> blogPosts = new List<BlogPost>();

        // Query multiple items from container
        using FeedIterator<BlogPost> feed = _container.GetItemQueryIterator<BlogPost>(
            queryText: "SELECT * FROM c"
        );

        // Iterate query result pages
        while (feed.HasMoreResults)
        {
            FeedResponse<BlogPost> response = await feed.ReadNextAsync();

            // Iterate query results
            foreach (BlogPost item in response)
            {
                blogPosts.Add(item);
            }
        }

        return blogPosts;
    }

    /// <inheritdoc/>
    public async Task UpdateBlogPostAsync(Guid id, string title, string content, string author, DateTime createdAt, bool isPublished, bool isDeleted)
    {
        var updatedBlogPost = new BlogPost
        {
            Id = id,
            Title = title,
            Content = content,
            Author = author,
            CreatedAt = createdAt,
            UpdatedAt = DateTime.UtcNow,
            IsPublished = isPublished,
            IsDeleted = isDeleted
        };

        try
        {
            await _container.ReplaceItemAsync(updatedBlogPost, updatedBlogPost.Id.ToString(), null);
        }
        catch (Exception ex)
        {
            if (ex is CosmosException cosmosException)
            {
                _logger.LogError($"Received {cosmosException.StatusCode} ({cosmosException.Message}).");
            }
            else
            {
                _logger.LogError($"Exception {ex}.");
            }
        }
    }
}

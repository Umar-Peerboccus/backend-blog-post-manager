using Blog.Post.Manager.Backend.Stores.Abstraction;
using Microsoft.Azure.Cosmos;

namespace Blog.Post.Manager.Backend.Stores.Cosmos;

/// <summary>
/// The store for blog posts.
/// </summary>
public class BlogPostStore : IBlogPostStore
{
    private readonly Container _container;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlogPostStore"/> class.
    /// </summary>
    /// <param name="cosmosClient">The cosmos client.</param>
    /// <param name="databaseName">The database name.</param>
    /// <param name="containerName">The container name.</param>
    public BlogPostStore(CosmosClient cosmosClient, string databaseName, string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }

    /// <inheritdoc/>
    public Task<Guid> CreateBlogPost(Guid id, string title, string content, string author, DateTime createdAt, DateTime UpdatedAt, bool isPublished, bool isDeleted)
    {
        throw new NotImplementedException();
    }
}

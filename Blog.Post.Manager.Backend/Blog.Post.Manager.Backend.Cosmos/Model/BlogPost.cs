using Newtonsoft.Json;

namespace Blog.Post.Manager.Backend.Cosmos.Model;

/// <summary>
/// The blog post data model to be stored in Cosmos DB NoSql.
/// </summary>
public record BlogPost
{
    /// <summary>
    /// Gets or sets the blog post identifier.
    /// </summary>
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    /// Gets or sets the content.
    /// </summary>
    public string Content { get; set; } = default!;

    /// <summary>
    /// Gets or sets the author of the post.
    /// </summary>
    public string Author { get; set; } = default!;

    /// <summary>
    /// Gets or sets the date the post was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date the post was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets the whether the post is publised.
    /// </summary>
    public bool IsPublished { get; set; }

    /// <summary>
    /// Gets or sets the whether the post is deleted.
    /// </summary>
    public bool IsDeleted { get; set; }
}

namespace Blog.Post.Manager.Backend.Models.requests;

public abstract class BlogPostRequestModel
{
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
    /// Gets or sets the whether the post is publised.
    /// </summary>
    public bool IsPublished { get; set; }

    /// <summary>
    /// Gets or sets the whether the post is deleted.
    /// </summary>
    public bool IsDeleted { get; set; }
}

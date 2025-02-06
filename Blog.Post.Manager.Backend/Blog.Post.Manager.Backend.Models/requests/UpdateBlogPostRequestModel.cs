namespace Blog.Post.Manager.Backend.Models.requests;

public class UpdateBlogPostRequestModel : BlogPostRequestModel
{
    /// <summary>
    /// Gets or sets the blog post identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the date the post was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date the post was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

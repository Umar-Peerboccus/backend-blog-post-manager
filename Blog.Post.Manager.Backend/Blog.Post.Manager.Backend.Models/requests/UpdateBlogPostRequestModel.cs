namespace Blog.Post.Manager.Backend.Models.requests;

public class UpdateBlogPostRequestModel : BlogPostRequestModel
{
    /// <summary>
    /// Gets or sets the date the post was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

}

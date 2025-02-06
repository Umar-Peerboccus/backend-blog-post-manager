namespace Blog.Post.Manager.Backend.Stores.Abstraction;

/// <summary>
/// The NoSql store for blog posts.
/// </summary>
public interface IBlogPostStore
{
    /// <summary>
    /// Create a blog post.
    /// </summary>
    /// <param name="id">The unique id of the blog post.</param>
    /// <param name="title">The title of the blog post.</param>
    /// <param name="content">The content of the blog post.</param>
    /// <param name="author">The author of the blog post.</param>
    /// <param name="createdAt">The date the blog post was created.</param>
    /// <param name="UpdatedAt">The last update date of the blog post.</param>
    /// <param name="isPublished">Is the blog post published or not.</param>
    /// <param name="isDeleted">Is the blog post deleted or not.</param>
    /// <returns></returns>
    Task<Guid> CreateBlogPost(Guid id, string title, string content, string author, DateTime createdAt, DateTime UpdatedAt, bool isPublished, bool isDeleted);
}

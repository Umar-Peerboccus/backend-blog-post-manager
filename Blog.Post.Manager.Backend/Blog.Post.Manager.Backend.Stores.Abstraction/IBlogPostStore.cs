using Blog.Post.Manager.Backend.Cosmos.Model;

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
    /// <returns>The identifier of blog post created.</returns>
    Task<Guid> CreateBlogPostAsync(string title, string content, string author, bool isPublished, bool isDeleted);

    /// <summary>
    /// Get all blog posts.
    /// </summary>
    /// <returns>A list of blog posts.</returns>
    Task<IList<BlogPost>> GetAllBlogPostAsync();

    /// <summary>
    /// Update a blog post.
    /// </summary>
    /// <param name="id">The unique id of the blog post.</param>
    /// <param name="title">The title of the blog post.</param>
    /// <param name="content">The content of the blog post.</param>
    /// <param name="author">The author of the blog post.</param>
    /// <param name="createdAt">The date the blog post was created.</param>
    /// <param name="isPublished">Is the blog post published or not.</param>
    /// <param name="isDeleted">Is the blog post deleted or not.</param>
    Task UpdateBlogPostAsync(Guid id, string title, string content, string author, DateTime createdAt, bool isPublished, bool isDeleted);

    /// <summary>
    /// Delete a blog post.
    /// </summary>
    /// <param name="id">The blog post identifier.</param>
    Task DeleteBlogPostAsync(Guid id);
}

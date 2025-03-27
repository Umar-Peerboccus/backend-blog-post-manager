using Blog.Post.Manager.Backend.Cosmos.Model;
using Blog.Post.Manager.Backend.Stores.Abstraction;

namespace Blog.Post.Manager.Backend.Stores.Cosmos;

/// <summary>
/// The store for blog posts.
/// </summary>
public class BlogPostStore : IBlogPostStore
{

    /// <summary>
    /// Initializes a new instance of the <see cref="BlogPostStore"/> class.
    /// </summary>
    /// <param name="cosmosClient">The cosmos client.</param>
    /// <param name="settings">The database settings.</param>
    /// <param name="logger">The logger.</param>
    public BlogPostStore()
    {
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

        return blogPost.Id;
    }

    /// <inheritdoc/>
    public async Task<IList<BlogPost>> GetAllBlogPostAsync()
    {
        List<BlogPost> blogPosts = new List<BlogPost>();
        blogPosts.Add(new BlogPost
        {
            Id = Guid.NewGuid(),
            Title = "Title",
            Content = "Content",
            Author = "Author",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsPublished = true,
            IsDeleted = false
        });

        blogPosts.Add(new BlogPost
        {
            Id = Guid.NewGuid(),
            Title = "Title_2",
            Content = "Content_2",
            Author = "Author_2",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsPublished = false,
            IsDeleted = false
        });

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
    }

    /// <inheritdoc/>
    public async Task DeleteBlogPostAsync(Guid id)
    {
      
    }
}

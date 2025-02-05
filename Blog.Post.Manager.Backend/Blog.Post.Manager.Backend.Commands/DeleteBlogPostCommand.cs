using MediatR;

namespace Blog.Post.Manager.Backend.Commands;

public class DeleteBlogPostCommand : IRequest
{
    // <summary>
    /// Gets or sets the blog post identifier.
    /// </summary>
    public Guid Id { get; set; }
}

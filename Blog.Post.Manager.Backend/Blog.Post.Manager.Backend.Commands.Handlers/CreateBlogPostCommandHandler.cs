using Blog.Post.Manager.Backend.Stores.Abstraction;
using MediatR;

namespace Blog.Post.Manager.Backend.Commands.Handlers;

/// <summary>
/// The command handler for creating a blog post.
/// </summary>
public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, Guid>
{
    public readonly IBlogPostStore _blogPostStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateBlogPostCommandHandler"/> class.
    /// </summary>
    /// <param name="blogPostStore">The blog store using NoSql.</param>
    public CreateBlogPostCommandHandler(IBlogPostStore blogPostStore)
    {
        _blogPostStore = blogPostStore;
    }

    public async Task<Guid> Handle(CreateBlogPostCommand command, CancellationToken cancellationToken)
    {
        // Creates the blog post in NoSql Cosmos DB.
        var id = await _blogPostStore.CreateBlogPostAsync(
            command.Title,
            command.Content,
            command.Author,
            command.IsPublished,
            command.IsDeleted);

        return id;
    }
}

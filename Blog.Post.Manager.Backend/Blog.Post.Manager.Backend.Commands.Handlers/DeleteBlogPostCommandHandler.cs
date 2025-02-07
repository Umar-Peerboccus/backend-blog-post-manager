using Blog.Post.Manager.Backend.Stores.Abstraction;
using MediatR;

namespace Blog.Post.Manager.Backend.Commands.Handlers;

public class DeleteBlogPostCommandHandler : IRequestHandler<DeleteBlogPostCommand>
{
    private readonly IBlogPostStore _blogPostStore;

    public DeleteBlogPostCommandHandler(IBlogPostStore blogPostStore)
    {
        _blogPostStore = blogPostStore;
    }

    public async Task Handle(DeleteBlogPostCommand command, CancellationToken cancellationToken)
    {
        await _blogPostStore.DeleteBlogPostAsync(command.Id);
    }
}

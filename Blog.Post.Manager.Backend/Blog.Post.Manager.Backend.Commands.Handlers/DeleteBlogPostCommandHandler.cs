using MediatR;

namespace Blog.Post.Manager.Backend.Commands.Handlers;

public class DeleteBlogPostCommandHandler : IRequestHandler<DeleteBlogPostCommand>
{
    public DeleteBlogPostCommandHandler()
    {

    }

    public Task Handle(DeleteBlogPostCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

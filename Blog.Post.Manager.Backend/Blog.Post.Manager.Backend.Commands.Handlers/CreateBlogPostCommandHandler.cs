using MediatR;

namespace Blog.Post.Manager.Backend.Commands.Handlers;

public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand>
{
    public CreateBlogPostCommandHandler()
    {

    }

    public Task Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

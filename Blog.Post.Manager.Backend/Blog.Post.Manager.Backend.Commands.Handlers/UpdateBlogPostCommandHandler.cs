using MediatR;

namespace Blog.Post.Manager.Backend.Commands.Handlers;

public class UpdateBlogPostCommandHandler : IRequestHandler<UpdateBlogPostCommand>
{
    public UpdateBlogPostCommandHandler()
    {

    }

    public Task Handle(UpdateBlogPostCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

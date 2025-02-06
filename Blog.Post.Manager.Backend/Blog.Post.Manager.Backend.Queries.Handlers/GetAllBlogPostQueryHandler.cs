using Blog.Post.Manager.Backend.Models;
using MediatR;

namespace Blog.Post.Manager.Backend.Queries.Handlers;

public class GetAllBlogPostQueryHandler : IRequestHandler<GetAllBlogPostQuery, IList<BlogPostModel>>
{
    public GetAllBlogPostQueryHandler()
    {

    }

    public Task<IList<BlogPostModel>> Handle(GetAllBlogPostQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
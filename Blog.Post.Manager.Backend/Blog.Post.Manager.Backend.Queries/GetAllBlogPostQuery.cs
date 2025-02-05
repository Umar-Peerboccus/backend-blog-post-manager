using MediatR;
using Blog.Post.Manager.Backend.Models;

namespace Blog.Post.Manager.Backend.Queries;

public class GetAllBlogPostQuery : IRequest<IList<BlogPostModel>>
{
}
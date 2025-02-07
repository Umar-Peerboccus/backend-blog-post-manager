using AutoMapper;
using Blog.Post.Manager.Backend.Models;
using Blog.Post.Manager.Backend.Stores.Abstraction;
using MediatR;

namespace Blog.Post.Manager.Backend.Queries.Handlers;

public class GetAllBlogPostQueryHandler : IRequestHandler<GetAllBlogPostQuery, IList<BlogPostModel>>
{
    public readonly IBlogPostStore _blogPostStore;
    private readonly IMapper _mapper;

    public GetAllBlogPostQueryHandler(IBlogPostStore blogPostStore, IMapper mapper)
    {
        _blogPostStore = blogPostStore;
        _mapper = mapper;
    }

    public async Task<IList<BlogPostModel>> Handle(GetAllBlogPostQuery query, CancellationToken cancellationToken)
    {
        var blogPostsList = await _blogPostStore.GetAllBlogPostAsync();
        return blogPostsList.Select(x => _mapper.Map<BlogPostModel>(x)).ToList();                          
    }
}
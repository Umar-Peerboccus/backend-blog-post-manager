using AutoMapper;
using Blog.Post.Manager.Backend.Cosmos.Model;
using Blog.Post.Manager.Backend.Stores.Abstraction;
using MediatR;

namespace Blog.Post.Manager.Backend.Commands.Handlers;

/// <summary>
/// The command handler to update a blog post.
/// </summary>
public class UpdateBlogPostCommandHandler : IRequestHandler<UpdateBlogPostCommand>
{
    public readonly IBlogPostStore _blogPostStore;
    public readonly IMapper _mapper;
    public UpdateBlogPostCommandHandler(IBlogPostStore blogPostStore, IMapper mapper)
    {
        _blogPostStore = blogPostStore;
        _mapper = mapper;
    }

    public async Task Handle(UpdateBlogPostCommand command, CancellationToken cancellationToken)
    {
        await _blogPostStore.UpdateBlogPostAsync(command.Id, command.Title, command.Content, command.Author, command.CreatedAt, command.IsPublished, command.IsDeleted);
    }
}

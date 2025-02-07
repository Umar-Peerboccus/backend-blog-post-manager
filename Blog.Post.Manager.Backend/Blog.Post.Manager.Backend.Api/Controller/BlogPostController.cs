using MediatR;
using Microsoft.AspNetCore.Mvc;
using Blog.Post.Manager.Backend.Queries;
using Blog.Post.Manager.Backend.Commands;
using Blog.Post.Manager.Backend.Models.requests;

namespace Blog.Post.Manager.Backend.Api.Controller;

/// <summary>
/// Manages the blog posts.
/// </summary>
[ApiController]
[Route("api/blog")]
public class BlogPostController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlogPostController"/> class.
    /// </summary>
    public BlogPostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create a blog post.
    /// </summary>
    /// <param name="request">The create blog request model.</param>
    /// <returns>The identifier of the blog post created.</returns>
    [HttpPost]
    [Produces("application/json")]
    public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestModel request)
    {
       var id = await _mediator.Send(
                new CreateBlogPostCommand
                {
                    Title = request.Title,
                    Content = request.Content,
                    Author = request.Author,
                    IsPublished = request.IsPublished,
                    IsDeleted = request.IsDeleted
                }); 
                                
        return Ok(id);
    }

    /// <summary>
    /// Gets all the blog posts.
    /// </summary>
    /// <returns>A list of blog post.</returns>
    [HttpGet]
    [Produces("application/json")]
    public async Task<IActionResult> GetAllBlogPost()
    {
        return Ok(await _mediator.Send(new GetAllBlogPostQuery()));
    }

    /// <summary>
    /// Update a blog post.
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces("application/json")]
    public async Task<IActionResult> UpdateBlogPost([FromRoute] Guid id, [FromBody] UpdateBlogPostRequestModel request)
    {
        await _mediator.Send(
                        new UpdateBlogPostCommand 
                        {
                            Id = id,
                            Title = request.Title,
                            Content = request.Content,
                            Author = request.Author,
                            CreatedAt = request.CreatedAt,
                            IsPublished = request.IsPublished,
                            IsDeleted = request.IsDeleted
                        });
        return Ok();
    }

    /// <summary>
    /// Delete a list of blog posts.
    /// </summary>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteBlogPosts([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteBlogPostCommand { Id = id });
        return Ok();
    }
}

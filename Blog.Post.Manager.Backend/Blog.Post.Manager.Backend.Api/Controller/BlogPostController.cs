using MediatR;
using Microsoft.AspNetCore.Mvc;
using Blog.Post.Manager.Backend.Queries;
using Blog.Post.Manager.Backend.Models;
using Microsoft.AspNetCore.Http;
using Blog.Post.Manager.Backend.Commands;

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
    /// <returns></returns>
    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBlogPost()
    {
        await _mediator.Send(
                new CreateBlogPostCommand
                {
                    Id = Guid.NewGuid(),
                    Title = "My first blog post",
                    Content = "This is my first blog post",
                    Author = "John Doe",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsPublished = true,
                    IsDeleted = false
                }); 
                                
        return Ok();
    }

    /// <summary>
    /// Gets all the blog posts.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<BlogPostModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllBlogPost()
    {
        return Ok(await _mediator.Send(new GetAllBlogPostQuery()));
    }

    /// <summary>
    /// Update a blog post.
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [Produces("application/json")]
    public async Task<IActionResult> UpdateBlogPost()
    {
        return Ok();
    }

    /// <summary>
    /// Delete a list of blog posts.
    /// </summary>
    /// <returns></returns>
    [HttpDelete("delete")]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteBlogPosts()
    {
        return Ok();
    }
}

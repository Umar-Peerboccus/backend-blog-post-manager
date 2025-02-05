using Microsoft.AspNetCore.Mvc;

namespace Blog.Post.Manager.Backend.Api.Controller;

/// <summary>
/// Manages the blog posts.
/// </summary>
[ApiController]
[Route("api/blog")]
public class BlogPostController : ControllerBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BlogPostController"/> class.
    /// </summary>
    public BlogPostController()
    {
        
    }

    /// <summary>
    /// Create a blog post.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Produces("application/json")]
    public async Task<IActionResult> CreateBlogPost()
    {
        return Ok();
    }

    /// <summary>
    /// Gets all the blog posts.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces("application/json")]
    public async Task<IActionResult> GetAllBlogPost()
    {
        return Ok();
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

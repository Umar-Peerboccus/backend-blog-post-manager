using Blog.Post.Manager.Backend.Cosmos.Model;
using Blog.Post.Manager.Backend.Stores.Abstraction;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace Blog.Post.Manager.Backend.Stores.Cosmos.UnitTests;

/// <summary>
/// Tests for blog post store using NSubstitute.
/// </summary>
public class BlogPostStoreTest
{
    private readonly IBlogPostStore _blogPostStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlogPostStoreTest"/> class.
    /// </summary>
    public BlogPostStoreTest()
    {
        _blogPostStore = Substitute.For<IBlogPostStore>();
    }

    #region GetAllBlogPostAsync

    /// <summary>
    /// GetAllBlogPostAsync() should return a list of blog posts.
    /// </summary>
    [Fact(DisplayName = "GetAllBlogPostAsync_ShouldReturnListOfBlogPosts")]
    public async Task GetPostAsync_ShouldReturnPost_WhenPostExists()
    {
        // Arrange
        var expectedPosts = new List<BlogPost>
        {
            new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Title 1",
                Content = "Content 1",
                Author = "Author 1",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsPublished = true,
                IsDeleted = false
            },
            new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Title 2",
                Content = "Content 2",
                Author = "Author 2",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsPublished = true,
                IsDeleted = false
            }
        };

        _blogPostStore.GetAllBlogPostAsync().Returns(expectedPosts);

        // Act
        var result = await _blogPostStore.GetAllBlogPostAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedPosts.Count, result.Count);
        Assert.Equal(expectedPosts.First().Title, result.First().Title);
    }
    #endregion

    #region CreateBlogPostAsync

    /// <summary>
    /// CreateBlogPostAsync() should return a the id of the blog post.
    /// </summary>
    [Fact(DisplayName = "CreateBlogPostAsync_ShouldReturnGuid_WhenBlogPostCreated")]
    public async Task CreateBlogPostAsync_ShouldReturnGuid_WhenBlogPostCreated()
    {
        // Arrange
        var expectedId = Guid.NewGuid();
        _blogPostStore.CreateBlogPostAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<bool>())
            .Returns(expectedId);

        // Act
        var id = await _blogPostStore.CreateBlogPostAsync("Title 1", "Content 1", "Author 1", true, false);

        // Assert
        Assert.Equal(expectedId, id);
    }
    #endregion

    #region UpdateBlogPostAsync

    /// <summary>
    /// UpdateBlogPostAsync() should update the blog post given the appropriate post d..
    /// </summary>
    [Fact(DisplayName = "UpdateBlogPostAsync_ShouldUpdateBlogPost_WhenBlogPostExists")]
    public async Task UpdateBlogPostAsync_ShouldUpdateBlogPost_WhenBlogPostExists()
    {
        // Arrange
        _blogPostStore.UpdateBlogPostAsync(Arg.Any<Guid>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<DateTime>(), Arg.Any<bool>(), Arg.Any<bool>())
            .Returns(Task.CompletedTask);

        // Act
        await _blogPostStore.UpdateBlogPostAsync(Guid.NewGuid(), "Title 1", "Content 1", "Author 1", DateTime.UtcNow, true, false);

        // Assert
        await _blogPostStore.Received(1).UpdateBlogPostAsync(Arg.Any<Guid>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<DateTime>(), Arg.Any<bool>(), Arg.Any<bool>());
    }

    /// <summary>
    /// UpdateBlogPostAsync() should throw an exception when the post id does not exist.
    /// </summary>
    [Fact(DisplayName = "UpdateBlogPostAsync_ShouldThrowException_WhenPostIdDoesNotExist")]
    public async Task UpdateBlogPostAsync_ShouldThrowException_WhenPostIdDoesNotExist()
    {
        // Arrange
        _blogPostStore.UpdateBlogPostAsync(Arg.Any<Guid>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<DateTime>(), Arg.Any<bool>(), Arg.Any<bool>())
            .Throws<Exception>();

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _blogPostStore.UpdateBlogPostAsync(Guid.NewGuid(), "Title 1", "Content 1", "Author 1", DateTime.UtcNow, true, false));
    }
    #endregion

    #region DeleteBlogPostAsync

    /// <summary>
    /// DeleteBlogPostAsync() should delete the blog post given the appropriate post id.
    /// </summary>
    [Fact(DisplayName = "DeleteBlogPostAsync_ShouldDeleteBlogPost_WhenBlogPostExists")]
    public async Task DeleteBlogPostAsync_ShouldDeleteBlogPost_WhenBlogPostExists()
    {
        // Arrange
        _blogPostStore.DeleteBlogPostAsync(Arg.Any<Guid>())
            .Returns(Task.CompletedTask);

        // Act
        await _blogPostStore.DeleteBlogPostAsync(Guid.NewGuid());

        // Assert
        await _blogPostStore.Received(1).DeleteBlogPostAsync(Arg.Any<Guid>());
    }

    /// <summary>
    /// DeleteBlogPostAsync() should throw an exception when the post id does not exist.
    /// </summary>
    [Fact(DisplayName = "DeleteBlogPostAsync_ShouldThrowException_WhenPostIdDoesNotExist")]
    public async Task DeleteBlogPostAsync_ShouldThrowException_WhenPostIdDoesNotExist()
    {
        // Arrange
        _blogPostStore.DeleteBlogPostAsync(Arg.Any<Guid>())
            .Throws<Exception>();

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _blogPostStore.DeleteBlogPostAsync(Guid.NewGuid()));
    }

    #endregion
}

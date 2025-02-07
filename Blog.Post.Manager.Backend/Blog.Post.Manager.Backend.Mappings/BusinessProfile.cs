using AutoMapper;
using Blog.Post.Manager.Backend.Cosmos.Model;
using Blog.Post.Manager.Backend.Models;

namespace Blog.Post.Manager.Backend.Mappings;

/// <summary>
/// Profile for mapping from NoSql Objects to DTO.
/// </summary>
public class BusinessProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessProfile"/> class.
    /// </summary>
    public BusinessProfile()
    {
        CreateMap<BlogPost, BlogPostModel>();
    }
}

using Blog.Post.Manager.Backend.Models.requests;
using FluentValidation;

namespace Blog.Post.Manager.Backend.Models.Validators.requests;

public class UpdateBlogPostRequestModelValidator : AbstractValidator<UpdateBlogPostRequestModel>
{
    public UpdateBlogPostRequestModelValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required.");
        RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required.");
        RuleFor(x => x.CreatedAt).NotEmpty().WithMessage("Date created is required.");
    }
}

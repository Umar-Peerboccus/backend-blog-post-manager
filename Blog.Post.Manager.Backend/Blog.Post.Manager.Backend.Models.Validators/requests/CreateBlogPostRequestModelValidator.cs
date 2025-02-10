using Blog.Post.Manager.Backend.Models.requests;
using FluentValidation;

namespace Blog.Post.Manager.Backend.Models.Validators.Requests;

public class CreateBlogPostRequestModelValidator : AbstractValidator<CreateBlogPostRequestModel>
{
    public CreateBlogPostRequestModelValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required.");
        RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required.");
    }
}

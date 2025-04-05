using FluentValidation;
using ProjectListHiumanLab.Domain.Dtos;

namespace ProjectListHiumanLab.Validators;

public class CreateProjectValidator : AbstractValidator<CreateProjectDto>
{
    public CreateProjectValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("The {PropertyName} field is required.");
        RuleFor(p => p.Description).NotEmpty().WithMessage("The {PropertyName} field is required.");
        RuleFor(p => p.Status).NotEmpty().WithMessage("The {PropertyName} field is required.");
    }
}

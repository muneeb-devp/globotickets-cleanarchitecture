using FluentValidation;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
  public CreateCategoryCommandValidator()
  {
    RuleFor(c => c.Name)
      .NotEmpty().WithMessage("Category name is required.")
      .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");
  }
}
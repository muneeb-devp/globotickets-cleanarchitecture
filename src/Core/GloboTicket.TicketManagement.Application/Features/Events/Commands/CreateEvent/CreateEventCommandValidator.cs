using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandValidator(IEventRepository eventRepository) : AbstractValidator<CreateEventCommand>
{
  public CreateEventCommandValidator()
  {
    RuleFor(e => e.Name)
      .NotEmpty().WithMessage("{PropertyName} is required.")
      .NotNull()
      .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

    RuleFor(e => e.Price)
      .NotEmpty().WithMessage("{PropertyName} is required.")
      .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");

    RuleFor(e => e)
      .MustAsync(EventNameAndDateUnique).WithMessage("An event with the same name and date already exists.")
      .Must(EventDateInFuture).WithMessage("{PropertyName} must be in the future.");

    // RuleFor(e => e.Artist)
    //   .NotEmpty().WithMessage("{PropertyName} is required.")
    //   .NotNull()
    //   .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

    RuleFor(e => e.Date)
      .NotEmpty().WithMessage("{PropertyName} is required.")
      .GreaterThan(DateTime.Now).WithMessage("{PropertyName} must be in the future.");

    // RuleFor(e => e.Description)
    //   .NotEmpty().WithMessage("{PropertyName} is required.")
    //   .NotNull()
    //   .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

    // RuleFor(e => e.ImageUrl)
    //   .NotEmpty().WithMessage("{PropertyName} is required.")
    //   .NotNull()
    //   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

    // RuleFor(e => e.CategoryId)
    //   .NotEmpty().WithMessage("{PropertyName} is required.")
    //   .NotNull();
  }

  private async Task<bool> EventNameAndDateUnique(CreateEventCommand command, CancellationToken cancellationToken)
  {
    return !(
      await eventRepository.IsEventNameAndDateUnique(command.Name, command.Date, cancellationToken)
    );
  }

  private bool EventDateInFuture(CreateEventCommand command)
  {
    return command.Date > DateTime.Now;
  }
}

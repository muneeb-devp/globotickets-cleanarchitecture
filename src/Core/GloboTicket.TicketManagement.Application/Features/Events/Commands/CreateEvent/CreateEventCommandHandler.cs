using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler(
  IMapper mapper,
  IEventRepository eventRepository,
  IEmailService emailService
) : IRequestHandler<CreateEventCommand, Guid>
{
  public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
  {
    var validator = new CreateEventCommandValidator(eventRepository);
    var validationResult = await validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      throw new Exceptions.BadRequestException("Invalid event details.");
    }

    var eventEntity = mapper.Map<Event>(request);
    var @event = await eventRepository.AddAsync(eventEntity);

    await emailService.SendEmailAsync(new Models.Email(
      From: "muneeb.devp@gmail.com",
      To: "muneeb.devp@gmail.com",
      Subject: "New Event Created",
      Body: $"A new event has been created: {@event.Name} on {@event.Date}."
    ));

    return @event.EventId;
  }
}

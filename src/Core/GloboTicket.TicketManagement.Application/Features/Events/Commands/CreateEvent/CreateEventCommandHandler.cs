using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository) : IRequestHandler<CreateEventCommand, Guid>
{
  public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
  {
    var validator = new CreateEventCommandValidator();
    var validationResult = await validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      throw new Exceptions.BadRequestException("Invalid event details.");
    }

    var eventEntity = mapper.Map<Event>(request);
    var @event = await eventRepository.AddAsync(eventEntity);

    return @event.EventId;
  }
}

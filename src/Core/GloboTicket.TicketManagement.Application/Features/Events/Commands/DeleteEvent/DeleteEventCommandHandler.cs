using System;
using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler(IMapper mapper, IEventRepository eventRepository) : IRequestHandler<DeleteEventCommand>
{
  public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
  {
    var eventToDelete = await eventRepository.GetByIdAsync(request.EventId);

    if (eventToDelete is null)
    {
      //throw new NotFoundException(nameof(Domain.Entities.Event), request.EventId);
    }

    await eventRepository.DeleteAsync(eventToDelete);
  }
}

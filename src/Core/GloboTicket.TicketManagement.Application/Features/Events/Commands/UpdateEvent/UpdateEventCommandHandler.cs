using System;
using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler(IMapper mapper, IEventRepository eventRepository) : IRequestHandler<UpdateEventCommand>
{
  public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
  {
    var eventToUpdate = await eventRepository.GetByIdAsync(request.EventId);

    mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Domain.Entities.Event));

    await eventRepository.UpdateAsync(eventToUpdate);
  }
}

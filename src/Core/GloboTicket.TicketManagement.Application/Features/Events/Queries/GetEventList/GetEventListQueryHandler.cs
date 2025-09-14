using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.ViewModels;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events;

public class GetEventListQueryHandler(IEventRepository eventRepository, IMapper mapper) : IRequestHandler<GetEventListQuery, List<EventListVm>>
{
  public async Task<List<EventListVm>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
  {
    var allEvents = await eventRepository.GetAllAsync();
    var sortedEvents = allEvents.OrderBy(e => e.Date).ToList();

    var mappedEvents = mapper.Map<List<EventListVm>>(sortedEvents);
    
    return mappedEvents ?? Enumerable.Empty<EventListVm>().ToList();
  }
}

using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events;

public class GetEventDetailQueryHandler(
  IRepository<Domain.Entities.Event> eventRepository,
  IRepository<Domain.Entities.Category> categoryRepository,
  IMapper mapper
) : IRequestHandler<GetEventDetailQuery, EventDetailVm>
{
  public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
  {
    var @event = await eventRepository.GetByIdAsync(request.EventId);
    var category = await categoryRepository.GetByIdAsync(@event?.CategoryId ?? Guid.Empty);
    var eventDetailDto = mapper.Map<EventDetailVm>(@event);

    eventDetailDto.Category = mapper.Map<CategoryDto>(category);
    eventDetailDto.Category.Id = eventDetailDto.CategoryId;
    return eventDetailDto;
  }
}

using System;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events;

public class GetEventDetailQuery : IRequest<EventDetailVm>
{
  public Guid EventId { get; set; }
}

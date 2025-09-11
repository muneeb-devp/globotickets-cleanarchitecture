using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence;

public interface IEventRepository : IRepository<Event>
{
  public Task<bool> IsEventNameAndDateUnique(string name, DateTime date, CancellationToken cancellationToken);
}

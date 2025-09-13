using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
  public EventRepository(GloboTicketDbContext dbContext) : base(dbContext) { }

  public async Task<bool> IsEventNameAndDateUnique(string name, DateTime date, CancellationToken cancellationToken)
  {
    var matches = await _dbContext.Events.AnyAsync(
        e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
        e.Date.Date.Equals(date.Date),
        cancellationToken);

    return !matches;
  }
}

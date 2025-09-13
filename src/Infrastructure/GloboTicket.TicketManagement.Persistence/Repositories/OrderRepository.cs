using GloboTicket.TicketManagement.Application.Contracts.Persistence;

namespace GloboTicket.TicketManagement.Persistence.Repositories;

public class OrderRepository : BaseRepository<Domain.Entities.Order>, IOrderRepository
{
  public OrderRepository(GloboTicketDbContext dbContext) : base(dbContext) { }
}

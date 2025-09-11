using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence;

public interface ICategoryRepository : IRepository<Category>
{
  Task<List<Category>> GetCategoriesWithEvents(bool includeHistory = false);
}

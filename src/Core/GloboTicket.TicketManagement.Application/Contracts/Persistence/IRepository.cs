namespace GloboTicket.TicketManagement.Application.Contracts.Persistence;

public interface IRepository<T> where T : class
{
  Task<T?> GetByIdAsync(Guid id);
  Task<IReadOnlyList<T>> GetAllAsync();
  Task<T> AddAsync(T entity);
  Task UpdateAsync(T entity);
  Task DeleteAsync(T entity);
}

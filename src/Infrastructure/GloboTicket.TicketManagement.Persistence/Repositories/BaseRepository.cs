using System;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
  protected readonly GloboTicketDbContext _dbContext;

  public BaseRepository(GloboTicketDbContext dbContext)
  {
    _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
  }

  public virtual async Task<T> AddAsync(T entity)
  {
    await _dbContext.Set<T>().AddAsync(entity);
    await _dbContext.SaveChangesAsync();
    return entity;
  }

  public virtual async Task DeleteAsync(T entity)
  {
    _dbContext.Set<T>().Remove(entity);
    await _dbContext.SaveChangesAsync();
  }

  public virtual async Task<IReadOnlyList<T>> GetAllAsync()
  {
    return await _dbContext.Set<T>().ToListAsync();
  }

  public virtual async Task<T?> GetByIdAsync(Guid id)
  {
    return await _dbContext.Set<T>().FindAsync(id);
  }

  public virtual async Task UpdateAsync(T entity)
  {
    _dbContext.Set<T>().Update(entity);
    await _dbContext.SaveChangesAsync();
  }
}

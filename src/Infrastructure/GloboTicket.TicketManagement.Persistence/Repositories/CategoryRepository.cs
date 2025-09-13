using System;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
  public CategoryRepository(GloboTicketDbContext dbContext) : base(dbContext) { }

  public Task<List<Category>> GetCategoriesWithEvents(bool includeHistory = false)
  {
    var categories = _dbContext.Categories.AsQueryable();

    if (includeHistory)
    {
      categories = categories.Include(c => c.Events);
    }
    else
    {
      var currentDate = DateTime.UtcNow;
      categories = categories.Include(c => c.Events.Where(e => e.Date >= currentDate));
    }

    return categories.ToListAsync();
  }
}

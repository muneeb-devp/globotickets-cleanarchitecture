using System;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent;

public class CategoryEventListVm
{
  public Guid CategoryId { get; set; }
  public string Name { get; set; } = string.Empty;

  public virtual ICollection<CategoryEventDto>? Events { get; set; }
}

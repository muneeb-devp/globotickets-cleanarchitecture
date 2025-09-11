namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent;

public class CategoryEventDto
{
  public Guid EventId { get; set; }
  public string Name { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public DateTime Date { get; set; }
  public string Artist { get; set; } = string.Empty;
  public Guid CategoryId { get; set; }
}
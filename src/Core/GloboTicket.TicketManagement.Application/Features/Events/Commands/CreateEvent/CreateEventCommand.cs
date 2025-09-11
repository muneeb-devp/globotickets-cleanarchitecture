

using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommand : IRequest<Guid>
{
  public string Name { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public string Artist { get; set; } = string.Empty;
  public DateTime Date { get; set; }
  public string Description { get; set; } = string.Empty;
  public string ImageUrl { get; set; } = string.Empty;

  public Guid CategoryId { get; set; }

  public override string ToString()
  {
    return $"Name: {Name}, Price: {Price}, Artist: {Artist}, Date: {Date}, Description: {Description}, ImageUrl: {ImageUrl}, CategoryId: {CategoryId}";
  }
}

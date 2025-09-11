namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands;

public abstract class BaseResponse
{
  public bool Success { get; set; } = true;
  public string Message { get; set; } = string.Empty;
  public IReadOnlyList<string>? ValidationErrors { get; set; }
}
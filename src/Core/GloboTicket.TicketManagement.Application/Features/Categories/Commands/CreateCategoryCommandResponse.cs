using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands;

public class CreateCategoryCommandResponse : BaseResponse
{
  public CreateCategoryDto Category { get; set; } = default!;
}

using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent;

public class GetCategoriesListWithEventQuery : IRequest<List<CategoryEventListVm>>
{
  public bool IncludeHistory { get; set; }
}

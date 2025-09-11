using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent;

public class GetCategoriesListWithEventQueryHandler(
  IMapper mapper,
  ICategoryRepository categoryRepository
) : IRequestHandler<GetCategoriesListWithEventQuery, List<CategoryEventListVm>>
{
  public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventQuery request, CancellationToken cancellationToken)
  {
    var categories = await categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
    return mapper.Map<List<CategoryEventListVm>>(categories);
  }
}

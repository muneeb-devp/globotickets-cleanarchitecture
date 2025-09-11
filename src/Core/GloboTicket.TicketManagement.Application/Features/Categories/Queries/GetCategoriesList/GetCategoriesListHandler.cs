using System;
using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoriesListHandler(
  IMapper mapper,
  ICategoryRepository categoryRepository
) : IRequestHandler<GetCategoriesList, List<CategoryListVm>>
{
  public async Task<List<CategoryListVm>> Handle(GetCategoriesList request, CancellationToken cancellationToken)
  {
    var categories = await categoryRepository.GetAllAsync();
    var sortedCategories = categories.OrderBy(c => c.Name);
    return mapper.Map<List<CategoryListVm>>(sortedCategories) ?? Enumerable.Empty<CategoryListVm>().ToList();
  }
}

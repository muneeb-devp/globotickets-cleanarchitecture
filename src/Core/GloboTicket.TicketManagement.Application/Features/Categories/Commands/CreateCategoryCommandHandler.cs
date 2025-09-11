using System;
using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands;

public class CreateCategoryCommandHandler(
  IMapper mapper,
  ICategoryRepository categoryRepository
) : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
  public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
  {
    var response = new CreateCategoryCommandResponse();

    var validator = new CreateCategoryCommandValidator();
    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    if (validationResult.Errors.Any())
    {
      response.Success = false;
      response.ValidationErrors = [.. validationResult.Errors.Select(err => err.ErrorMessage)];
    }

    if (response.Success is not false)
    {
      var category = new Category { Name = request.Name };
      category = await categoryRepository.AddAsync(category);
      response.Category = mapper.Map<CreateCategoryDto>(category);
      response.Message = "Category created successfully.";
    }

    return response;
  }
}

public class CreateCategoryDto
{
  public string Name { get; set; } = default!;
}

using GloboTicket.TicketManagement.Application.Features.Categories.Commands;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(IMediator mediator) : ControllerBase
{
    [HttpGet(Name = "GetCategoriesList")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CategoryListVm>> GetAll()
    {
        var dtos = await mediator.Send(new GetCategoriesListQuery());
        return Ok(dtos);
    }

    [HttpGet]
    [Route("{includeHistory}", Name = "GetCategoriesListHistory")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CategoryEventListVm>> GetCategoriesWithEvents(bool includeHistory)
    {
        var dtos = await mediator.Send(new GetCategoriesListWithEventQuery { IncludeHistory = includeHistory });
        return Ok(dtos);
    }

    [HttpGet("add", Name = "AddCategory")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        var response = await mediator.Send(createCategoryCommand);
        return Ok(response);
    }
}
using System;
using AutoMapper;
using GloboTicket.TicketManagement.Api.Utilities;
using GloboTicket.TicketManagement.Application.Features.Events;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.ExportEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController(IMediator mediator) : ControllerBase
{
  [HttpGet(Name = "GetEventsList")]
  public async Task<ActionResult<EventListVm>> GetAll()
  {
    var dtos = await mediator.Send(new GetEventListQuery());
    return Ok(dtos);
  }

  [HttpGet("{id}", Name = "GetEventDetail")]
  public async Task<ActionResult<EventDetailVm>> Get(Guid id)
  {
    var dto = await mediator.Send(new GetEventDetailQuery { EventId = id });
    return Ok(dto);
  }

  [HttpPost("add", Name = "AddEvent")]
  public async Task<ActionResult> Create(CreateEventCommand createEventCommand)
  {
    var response = await mediator.Send(createEventCommand);
    return Ok(response);
  }

  [HttpPost("update", Name = "UpdateEvent")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<ActionResult> Update(UpdateEventCommand updateEventCommand)
  {
    await mediator.Send(updateEventCommand);
    return NoContent();
  }

  [HttpDelete("{id}", Name = "DeleteEvent")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<ActionResult> Delete(Guid id)
  {
    await mediator.Send(new DeleteEventCommand { EventId = id });
    return NoContent();
  }

  [HttpGet("export", Name = "ExportEvents")]
  [FileResultContentType("text/csv")]
  public async Task<FileResult> ExportEvents()
  {
    var fileDto = await mediator.Send(new ExportEventQuery());
    
    return File(fileDto.Data, fileDto.ContentType, fileDto.EventExportFileName);
  }
}

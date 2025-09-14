using AutoMapper;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent;
using GloboTicket.TicketManagement.Application.Features.Events;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.ExportEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.ViewModels;

namespace GloboTicket.TicketManagement.Application.Profiles;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Domain.Entities.Event, EventListVm>().ReverseMap();
    CreateMap<Domain.Entities.Event, EventDetailVm>().ReverseMap();
    CreateMap<Domain.Entities.Event, CreateEventCommand>().ReverseMap();
    CreateMap<Domain.Entities.Event, UpdateEventCommand>().ReverseMap();
    CreateMap<Domain.Entities.Event, DeleteEventCommand>().ReverseMap();
    CreateMap<Domain.Entities.Event, EventExportDto>().ReverseMap();

    CreateMap<Domain.Entities.Category, CategoryDto>().ReverseMap();
    CreateMap<Domain.Entities.Category, CategoryEventListVm>().ReverseMap();
    CreateMap<Domain.Entities.Category, CategoryListVm>().ReverseMap();
  }
}

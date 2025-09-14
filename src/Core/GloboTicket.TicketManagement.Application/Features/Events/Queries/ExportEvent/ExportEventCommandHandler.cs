using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.ExportEvent;

public class ExportEventCommandHandler(
    IMapper mapper,
    IRepository<Event> eventRepo,
    ICsvExporter csvExporter
) : IRequestHandler<ExportEventQuery, EventExportFileVm>
{
    public async Task<EventExportFileVm> Handle(ExportEventQuery request, CancellationToken cancellationToken)
    {
        var allEvents = mapper.Map<List<EventExportDto>>(
            (await eventRepo.GetAllAsync()).OrderBy(x => x.Date)
        );
        var fileData = csvExporter.ExportToCsv<EventExportDto>(allEvents.ToList());
        var eventExportFileDto = new EventExportFileVm
        {
            ContentType = "text/csv",
            Data = fileData,
            EventExportFileName = $"{Guid.NewGuid()}.csv"
        };

        return eventExportFileDto;
    }
}
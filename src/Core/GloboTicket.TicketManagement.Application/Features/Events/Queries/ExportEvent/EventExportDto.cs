namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.ExportEvent;

public class EventExportDto
{
    public Guid EventId { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
}
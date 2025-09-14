using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.ExportEvent;

public class ExportEventQuery : IRequest<EventExportFileVm> { }

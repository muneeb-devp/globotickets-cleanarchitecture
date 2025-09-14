namespace GloboTicket.TicketManagement.Application.Contracts.Infrastructure;

public interface ICsvExporter
{
    byte[] ExportToCsv<T>(IList<T> records);
}
using CsvHelper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;

namespace GloboTicket.TicketManagement.Infrastructure.Export;

public class CsvExporter : ICsvExporter
{
    public byte[] ExportToCsv<T>(IList<T> records)
    {
        using var memoryStream = new MemoryStream();
        using var streamWriter = new StreamWriter(memoryStream);
        using var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.InvariantCulture);

        csvWriter.WriteRecords(records);
        streamWriter.Flush();
        
        return memoryStream.ToArray();
    }
}
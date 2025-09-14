namespace GloboTicket.TicketManagement.Api.Utilities;

[AttributeUsage(AttributeTargets.Method)]
public class FileResultContentTypeAttribute : Attribute
{
    public string ContentType { get; set; }
    
    public FileResultContentTypeAttribute(string contentType)
    {
        ContentType = contentType;    
    }
}
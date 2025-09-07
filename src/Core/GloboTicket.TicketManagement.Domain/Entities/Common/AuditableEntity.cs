namespace GloboTicket.TicketManagement.Domain.Entities.Common;

public abstract class AuditableEntity
{
  public string CreatedBy { get; set; } = string.Empty;
  public DateTime CreatedDate { get; set; }
  public string? LastModifiedBy { get; set; }
  public DateTime? LastModifiedDate { get; set; }
}
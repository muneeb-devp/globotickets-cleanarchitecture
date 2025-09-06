using GloboTicket.TicketManagement.Domain.Entities.Common;

namespace GloboTicket.TicketManagement.Domain.Entities;

public class Order : AuditableEntity
{
  public Guid OrderId { get; set; }
  public string UserId { get; set; } = string.Empty;
  public DateTime OrderDate { get; set; }
  public decimal TotalAmount { get; set; }
  public bool OrderPaid { get; set; } = false;

}
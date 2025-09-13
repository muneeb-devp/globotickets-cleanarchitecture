namespace GloboTicket.TicketManagement.Application.Models;

public record EmailSettings(
  string FromAddress,
  string ApiKey,
  string FromName
);

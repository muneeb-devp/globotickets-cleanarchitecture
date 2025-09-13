namespace GloboTicket.TicketManagement.Application.Models;

public record Email(
  string From,
  string To,
  string Subject,
  string Body
);

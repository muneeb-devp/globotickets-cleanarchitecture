using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GloboTicket.TicketManagement.Infrastructure.Mail;

public class EmailService : IEmailService
{
  public EmailSettings _emailSettings { get; }

  public EmailService(IOptions<EmailSettings> emailSettings)
  {
    _emailSettings = emailSettings.Value;
  }

  public async Task<bool> SendEmailAsync(Email email)
  {
    var client = new SendGridClient(_emailSettings.ApiKey);
    var fromAddress = new EmailAddress(email.From);
    var toAddress = new EmailAddress(email.To);

    var message = MailHelper.CreateSingleEmail(
      fromAddress,
      toAddress,
      email.Subject,
      email.Body,
      email.Body
    );

    var response = await client.SendEmailAsync(message);

    if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
    {
      return true;
    }

    return false;
  }
}

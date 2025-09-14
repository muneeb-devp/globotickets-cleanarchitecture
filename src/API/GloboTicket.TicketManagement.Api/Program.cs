using GloboTicket.TicketManagement.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder
                        .ConfigureServices()
                        .ConfigurePipeline();

app.MapGet("/", () => "Welcome to GloboTicket Ticket Management API!");

await app.ResetDatabaseAsync();
app.Run();

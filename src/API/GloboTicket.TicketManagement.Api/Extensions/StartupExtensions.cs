using System;
using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Infrastructure;
using GloboTicket.TicketManagement.Persistence;

namespace GloboTicket.TicketManagement.Api.Extensions;

public static class StartupExtensions
{
  public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
  {
    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.AddPersistenceServices(builder.Configuration);

    builder.Services.AddControllers();

    builder.Services.AddCors(opt => opt.AddPolicy(
      "open",
      policy => policy.WithOrigins([
          builder.Configuration["ApiUrl"] ?? "http://localhost:7200",
          builder.Configuration["BlazorUrl"] ?? "https://localhost:7001"
        ])
        .AllowAnyMethod()
        .SetIsOriginAllowed(pol => true)
        .AllowAnyHeader()
        .AllowCredentials()
    ));

    builder.Services.AddSwaggerGen();
    
    return builder.Build();
  }

  public static WebApplication ConfigurePipeline(this WebApplication app)
  {
    app.UseCors();

    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

  app.UseHttpsRedirection();
    app.MapControllers();

    return app;
  }

  public static async Task ResetDatabaseAsync(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
      var context = services.GetRequiredService<GloboTicketDbContext>();
      await context.Database.EnsureDeletedAsync();
      await context.Database.EnsureCreatedAsync();
    }
    catch (Exception ex)
    {
      var logger = services.GetRequiredService<ILogger<Program>>();
      logger.LogError(ex, "An error occurred while resetting the database.");
    }
  }
}

using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.TicketManagement.Persistence;

public static class PersistenceServiceRegistration
{
  public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<GloboTicketDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("GloboTicketConnectionString")));

    services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
    services.AddScoped<IEventRepository, EventRepository>();
    services.AddScoped<ICategoryRepository, CategoryRepository>();
    services.AddScoped<IOrderRepository, OrderRepository>();

    return services;
  }
}

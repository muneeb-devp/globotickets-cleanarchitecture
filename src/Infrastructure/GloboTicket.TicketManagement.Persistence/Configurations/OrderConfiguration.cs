using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GloboTicket.TicketManagement.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Domain.Entities.Order>
{
  public void Configure(EntityTypeBuilder<Order> builder)
  {
    builder.ToTable("orders", schema: "globoticket");

    builder.Property(o => o.OrderId).IsRequired();
    builder.Property(o => o.UserId).IsRequired();
    builder.Property(o => o.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");
    builder.Property(o => o.OrderPaid).IsRequired().HasDefaultValue(false);
  }
}

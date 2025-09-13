using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GloboTicket.TicketManagement.Persistence.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
  public void Configure(EntityTypeBuilder<Event> builder)
  {
    builder.ToTable("events", schema: "globoticket");

    builder.Property(e => e.Name)
      .IsRequired()
      .HasMaxLength(50);

    builder.Property(e => e.Price)
      .IsRequired()
      .HasColumnType("decimal(18,2)");

    builder.Property(e => e.Artist)
      .IsRequired()
      .HasMaxLength(50);

    builder.Property(e => e.Date)
      .IsRequired();

    builder.Property(e => e.Description)
      .HasMaxLength(500);

    builder.Property(e => e.ImageUrl)
      .HasMaxLength(100);

    builder.HasOne(e => e.Category)
      .WithMany(c => c.Events)
      .HasForeignKey(e => e.CategoryId);
  }
}

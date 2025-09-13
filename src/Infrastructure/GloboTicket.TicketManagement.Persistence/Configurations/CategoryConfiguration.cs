using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GloboTicket.TicketManagement.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Domain.Entities.Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    builder.ToTable("categories", schema: "globoticket");
    builder.Property(c => c.Name)
      .IsRequired()
      .HasMaxLength(64);
  }
}

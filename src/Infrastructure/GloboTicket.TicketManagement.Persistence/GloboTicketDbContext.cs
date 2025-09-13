
using GloboTicket.TicketManagement.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence;

public class GloboTicketDbContext : DbContext
{
  public DbSet<Domain.Entities.Event> Events => Set<Domain.Entities.Event>();
  public DbSet<Domain.Entities.Category> Categories => Set<Domain.Entities.Category>();
  public DbSet<Domain.Entities.Order> Orders => Set<Domain.Entities.Order>();


  public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);

    modelBuilder.Entity<Domain.Entities.Category>().ToTable("categories", schema: "globoticket");
    modelBuilder.Entity<Domain.Entities.Event>().ToTable("events", schema: "globoticket");
    modelBuilder.Entity<Domain.Entities.Order>().ToTable("orders", schema: "globoticket");

    // Seed data
    var concertId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
    var musicalId = Guid.Parse("{63A0875A-29D3-4B2E-B9E5-0C8A4EAA3AF1}");
    var playId = Guid.Parse("{D3805A73-7C0E-4F8E-AB8A-3B8D5C4E0B51}");
    var conferenceId = Guid.Parse("{9E3D5F1C-2A1C-4F3B-8E2D-5F7A9C6B4D3E}");

    modelBuilder.Entity<Domain.Entities.Category>().HasData(
      new Domain.Entities.Category
      {
        CategoryId = concertId,
        Name = "Concert"
      },
      new Domain.Entities.Category
      {
        CategoryId = musicalId,
        Name = "Musical"
      },
      new Domain.Entities.Category
      {
        CategoryId = playId,
        Name = "Play"
      },
      new Domain.Entities.Category
      {
        CategoryId = conferenceId,
        Name = "Conference"
      }
    );

    modelBuilder.Entity<Domain.Entities.Event>().HasData(
      new Domain.Entities.Event
      {
        EventId = Guid.Parse("{A1E2D3C4-B5F6-4789-8A9B-C0D1E2F3A4B5}"),
        Name = "Rock Concert",
        Price = 59.99M,
        Artist = "The Rockers",
        Date = new DateTime(2025, 11, 15, 20, 0, 0),
        Description = "An electrifying rock concert featuring The Rockers.",
        ImageUrl = "https://images.unsplash.com/photo-1511671782779-c97d3d27a1d4?auto=format&fit=crop&w=800&q=80",
        CategoryId = concertId
      },
      new Domain.Entities.Event
      {
        EventId = Guid.Parse("{B1C2D3E4-F5A6-4789-9A0B-C1D2E3F4B5C6}"),
        Name = "Broadway Musical",
        Price = 79.99M,
        Artist = "Broadway Stars",
        Date = new DateTime(2025, 12, 5, 19, 30, 0),
        Description = "A spectacular Broadway musical performance.",
        ImageUrl = "https://images.unsplash.com/photo-1464983953574-0892a716854b?auto=format&fit=crop&w=800&q=80",
        CategoryId = musicalId
      },
      new Domain.Entities.Event
      {
        EventId = Guid.Parse("{C1D2E3F4-A5B6-4789-0A1B-C2D3E4F5B6C7}"),
        Name = "Shakespeare Play",
        Price = 49.99M,
        Artist = "Classic Theatre Group",
        Date = new DateTime(2026, 10, 20, 18, 0, 0),
        Description = "A timeless Shakespeare play performed by the Classic Theatre Group.",
        ImageUrl = "https://images.unsplash.com/photo-1506744038136-46273834b3fb?auto=format&fit=crop&w=800&q=80",
        CategoryId = playId
      },
      new Domain.Entities.Event
      {
        EventId = Guid.Parse("{D1E2F3A4-B5C6-4789-1A2B-C3D4E5F6B7C8}"),
        Name = "Tech Conference",
        Price = 199.99M,
        Artist = "Industry Leaders",
        Date = new DateTime(2026, 9, 10, 9, 0, 0),
        Description = "A leading tech conference with talks from industry leaders.",
        ImageUrl = "https://images.unsplash.com/photo-1519389950473-47ba0277781c?auto=format&fit=crop&w=800&q=80",
        CategoryId = conferenceId
      }
    );
  }

  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    ChangeTracker.Entries<AuditableEntity>().ToList().ForEach(entry =>
    {
      switch (entry.State)
      {
        case EntityState.Added:
          entry.Entity.CreatedDate = DateTime.UtcNow;
          break;
        case EntityState.Modified:
          entry.Entity.LastModifiedDate = DateTime.UtcNow;
          break;
      }
    });

    return base.SaveChangesAsync(cancellationToken);
  }
}

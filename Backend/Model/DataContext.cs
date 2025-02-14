using Backend.Model;
using Microsoft.EntityFrameworkCore;
namespace backend.Model;

public class DataContext: DbContext {
    public DataContext(DbContextOptions<DataContext> options): base(options) {}
    public DbSet<Event>? EventList {get; set;}
    public DbSet<Resident>? ResidentList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Event>().Property(p => p.Id).HasIdentityOptions(startValue: 4);

        modelBuilder.Entity<Event>().HasData(
            new Event
            {
                Id = 1,
                Type = "Hiveworld",
                Description = "Trillions denizens live here.",
                Location = "Seguntum I",
                Date = new DateTime()
            },
            new Event
            {
                Id = 2,
                Type = "Agriworld",
                Description = "Starch for the masses.",
                Location = "Valtrox VII",
                Date = new DateTime()
            },
            new Event
            {
                Id = 3,
                Type = "Deathworld",
                Description = "WHY ARE YOU HERE!?",
                Location = "Eye of Terror",
                Date = new DateTime()
            }
            );

        modelBuilder.Entity<Resident>().Property(p => p.Id).HasIdentityOptions(startValue: 4);

        modelBuilder.Entity<Resident>().HasData(
            new Resident
            {
                Id = 1,
                Name = "Hiveworld",
                Description = "Trillions denizens live here.",
                Job = "Seguntum I",
                BirthDate = new DateTime()
            },
            new Resident
            {
                Id = 2,
                Name = "Agriworld",
                Description = "Starch for the masses.",
                Job = "Valtrox VII",
                BirthDate = new DateTime()
            },
            new Resident
            {
                Id = 3,
                Name = "Deathworld",
                Description = "WHY ARE YOU HERE!?",
                Job = "Eye of Terror",
                BirthDate = new DateTime()
            }
        );

    }
}




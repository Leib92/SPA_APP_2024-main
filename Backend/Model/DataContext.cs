using Microsoft.EntityFrameworkCore;
namespace backend.Model;

public class DataContext: DbContext {
    public DataContext(DbContextOptions<DataContext> options): base(options) {}
    public DbSet<Event>? EventList {get; set;}

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

    }
}




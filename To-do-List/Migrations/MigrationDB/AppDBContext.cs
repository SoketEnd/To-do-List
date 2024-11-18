using Microsoft.EntityFrameworkCore;
using To_do_List.Migrations.ModelDB;

namespace To_do_List.Migrations.Migration;

internal class AppDBContext : DbContext
{
    public AppDBContext()
    {
        Database.EnsureCreated();
    }

    public DbSet<Model> Models { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-582CB1R;Database=DataBaseTo_DO_LIST;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Model>().HasKey(m => m.Id);
        base.OnModelCreating(modelBuilder);
    }
}

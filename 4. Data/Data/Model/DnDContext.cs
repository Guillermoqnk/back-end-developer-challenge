using Data.Entities;
using Data.Model.Entities;
using DnDBeyondAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DnDBeyondAPI;

public class DnDContext : DbContext
{
    public DnDContext(DbContextOptions<DnDContext> options) : base(options) { 
    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<Class> Class { get; set; }
    public DbSet<Defense> Defense { get; set; }
    public DbSet<Item> Item { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>().ToTable("Character");
        modelBuilder.Entity<Class>().ToTable("Class");
        modelBuilder.Entity<Defense>().ToTable("Defense");
        modelBuilder.Entity<Item>().ToTable("Item");
        modelBuilder.Entity<Stats>().ToTable("Stats");
    }
}

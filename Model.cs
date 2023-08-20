using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RavenloftContext : DbContext
{
    public DbSet<TraitAppearance> traitAppearances { get; set; }
    public DbSet<LocationAppearance> locationAppearances { get; set; }
    public DbSet<NPCAppearance> npcAppearances { get; set; }
    public DbSet<DomainAppearance> domainAppearances { get; set; }
    public DbSet<ItemAppearance> itemAppearances { get; set; }
    
    public DbSet<Relationship> Relationships { get; set; }

    public DbSet<Source> Sources { get; set; }
    public DbSet<SourceTrait> SourceTraits { get; set; }

    public DbSet<Trait> Traits { get; set; }

    public DbSet<Item> Items { get; set; }
    public DbSet<Domain> Domains { get; set; }
    public DbSet<NPC> NPCs { get; set; }
    public DbSet<Location> Locations { get; set; }

    public string DbPath { get; }
    public RavenloftContext() => DbPath = Path.Join(Directory.GetCurrentDirectory(), "Ravenloft.db");

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
        options.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Relationship>().Property(e => e.Type).HasConversion(
            v => v.ToString(),
            v => (Relationship.RelationshipType)Enum.Parse(typeof(Relationship.RelationshipType), v)
        );

        modelBuilder.Entity<NPC>()
            .HasMany(n => n.Relationships)
            .WithOne(r => r.Primary);

        modelBuilder.Entity<Relationship>()
            .HasOne(r => r.Other)
            .WithOne(n => n.IgnoreThis)
            .HasForeignKey<Relationship>(r => r.OtherId)
            .OnDelete(DeleteBehavior.Restrict);

        /*modelBuilder.Entity<Relationship>()
            .HasOne(r => r.Other)
            .WithMany(u => u.Relationships)
            .HasForeignKey(r => r.OtherId)
            .OnDelete(DeleteBehavior.Restrict);*/
                   
        modelBuilder.Entity<Appearance>().ToTable("Appearances");
        modelBuilder.Entity<TraitAppearance   >().Property(a => a.EntityName).HasColumnName("Trait");
        modelBuilder.Entity<LocationAppearance>().Property(a => a.EntityId).HasColumnName("Location");
        modelBuilder.Entity<NPCAppearance     >().Property(a => a.EntityId).HasColumnName("NPC");
        modelBuilder.Entity<DomainAppearance  >().Property(a => a.EntityId).HasColumnName("Domain");
        modelBuilder.Entity<ItemAppearance    >().Property(a => a.EntityId).HasColumnName("Item");

        base.OnModelCreating(modelBuilder);
    }
}
public abstract class UseId
{
    public int Id { get; set; }
    public string Name { get; set; } //Can be different in different sources
    public string Search { get; set; } //This will be fixed for searching.
    public string ExtraInfo { get; set; } = string.Empty;
}
public abstract class UseName
{
    [Key] public string Name { get; set; }
    public string ExtraInfo { get; set; } = string.Empty; //external links
}
public class Source : UseName
{
    public List<SourceTrait> Traits { get; set; }
    [Column(TypeName = "Date")] public DateTime ReleaseDate { get; set; }
    //Levels, contributors, release date
}
public class SourceTrait : UseName
{
    public string Type { get; set; }
    public List<Source> Sources { get; set; } = new();
}
public class Trait : UseName
{
    public string Type { get; set; }
    public List<Domain> Domains { get; set; } = new();
    public List<Location> Locations { get; set; } = new();
    public List<Item> Items { get; set; } = new();
    public List<NPC> NPCs { get; set; } = new();
}
public class Domain : UseId
{
    public List<Location> Locations { get; set; } = new();
    public List<NPC> NPCs { get; set; } = new();
    public List<Trait> Traits { get; set; } = new();
    public List<Item> Items { get; set; } = new();
    //Recommended related media, recorded sessions
}
public class Location : UseId
{
    public List<Domain> Domains { get; set; } = new();
    public List<NPC> NPCs { get; set; } = new();
    public List<Trait> Traits { get; set; } = new();
    //public string Population { get; set; } //Maybe a number would be better
}
public class Item : UseId
{
    public List<Domain> Domains { get; set; } = new();
    public List<Trait> Traits { get; set; } = new();
}
public class NPC : UseId
{

    //public string Damnation; //Event that damned them to their own Domain
    //public string Curse; //What do they have to live with
    //public string ClosedBorders; //When they close the borders, how does it manifest
    public List<Domain> Domains { get; set; } = new();
    public List<Location> Locations { get; set; } = new();
    public List<Trait> Traits { get; set; } = new();
    public List<Relationship> Relationships { get; set; } = new ();
    public Relationship IgnoreThis { get; set; }
}
public class Relationship
{
    public int Id { get; set; }
    public int PrimaryId { get; set; }
    public NPC Primary { get; set; }
    public int OtherId { get; set; }
    public NPC Other { get; set; } = new();
    public enum RelationshipType { Parent, Adopted, Spouse }
    public RelationshipType Type { get; set; }
}

public abstract class Appearance
{
    public int Id { get; set; }
    public Source Source { get; set; }
    public string PageNumbers { get; set; }
}
public class TraitAppearance : Appearance
{
    public Trait Entity { get; set; }
    public int EntityName { get; set; }
}
public class LocationAppearance : Appearance
{
    public Location Entity { get; set; }
    public int EntityId { get; set; }
}
public class NPCAppearance : Appearance
{
    public NPC Entity { get; set; }
    public int EntityId { get; set; }
}
public class DomainAppearance : Appearance
{
    public Domain Entity { get; set; }
    public int EntityId { get; set; }
}
public class ItemAppearance : Appearance
{
    public Item Entity { get; set; }
    public int EntityId { get; set; }
}
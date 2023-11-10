using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RavenloftContext : DbContext
{
    public DbSet<LocationAppearance> locationAppearances { get; set; }
    public DbSet<NPCAppearance> npcAppearances { get; set; }
    public DbSet<DomainAppearance> domainAppearances { get; set; }
    public DbSet<ItemAppearance> itemAppearances { get; set; }
    
    public DbSet<Relationship> Relationships { get; set; }

    public DbSet<Source> Sources { get; set; }
    public DbSet<Source.Trait> SourceTraits { get; set; }

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

        modelBuilder.Entity<Relationship>()
            .HasOne(r => r.Primary)
            .WithMany(n => n.Relationships)
            .HasForeignKey(r => r.PrimaryName)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Relationship>()
            .HasOne(r => r.Other)
            .WithMany(n => n.IgnoreThis)
            .HasForeignKey(r => r.OtherName)
            .OnDelete(DeleteBehavior.Restrict);
                   
        modelBuilder.Entity<Appearance>().ToTable("Appearances");

        base.OnModelCreating(modelBuilder);
    }
}
public abstract class UseVariableName : UseName
{
    public string Name { get; set; } //Can be different in different sources
    public string OriginalName { get; set; } //For searching purposes
    public HashSet<Trait> Traits { get; set; } = new();
}
public abstract class UseName
{
    [Key] public string Key { get; set; } //Key
    public string ExtraInfo { get; set; } = string.Empty; //external links
}
public class Source : UseName
{
    public List<Trait> Traits { get; set; }
    public string ReleaseDate { get; set; }
    //Levels, contributors, release date
    public class Trait : UseName
    {
        public string Type { get; set; }
        public HashSet<Source> Sources { get; set; } = new();
    }
}
public class Trait : UseName
{
    public string Type { get; set; }
    public HashSet<Domain> Domains { get; set; } = new();
    public HashSet<Location> Locations { get; set; } = new();
    public HashSet<Item> Items { get; set; } = new();
    public HashSet<NPC> NPCs { get; set; } = new();
}
public class Domain : UseVariableName
{
    public HashSet<Location> Locations { get; set; } = new();
    public HashSet<NPC> NPCs { get; set; } = new();
    public HashSet<Item> Items { get; set; } = new();
    //Recommended related media, recorded sessions
}
public class Location : UseVariableName
{
    public HashSet<Domain> Domains { get; set; } = new();
    public HashSet<NPC> NPCs { get; set; } = new();
}
public class Item : UseVariableName
{
    public HashSet<Domain> Domains { get; set; } = new();
}
public class NPC : UseVariableName
{
    public HashSet<Domain> Domains { get; set; } = new();
    public HashSet<Location> Locations { get; set; } = new();
    public HashSet<Relationship> Relationships { get; set; } = new ();
    public HashSet<Relationship> IgnoreThis { get; set; } = new ();
    //string Damnation; //Event that damned them to their own Domain
    //string Curse; //What do they have to live with
    //string ClosedBorders; //When they close the borders, how does it manifest
}
public class Relationship
{
    public int Id { get; set; }
    public string PrimaryName { get; set; }
    public NPC Primary { get; set; }
    public string OtherName { get; set; }
    public NPC Other { get; set; } = new();
    public enum RelationshipType { Parent, Adopted, Spouse }
    public RelationshipType Type { get; set; }
}
public abstract class Appearance
{
    public int Id { get; set; }
    public Source Source { get; set; }
    [Column("Source")] public string SourceKey { get; set; }
    public string PageNumbers { get; set; }
}
public interface IHasEntity<T>
{
    T Entity { get; set; }
}
public class LocationAppearance : Appearance, IHasEntity<Location>
{
    public Location Entity { get; set; }
    [Column("Location")] public string EntityId { get; set; }
}
public class NPCAppearance : Appearance, IHasEntity<NPC>
{
    public NPC Entity { get; set; }
    [Column("NPC")] public string EntityId { get; set; }
}
public class DomainAppearance : Appearance, IHasEntity<Domain>
{
    public Domain Entity { get; set; }
    [Column("Domain")] public string EntityId { get; set; }
}
public class ItemAppearance : Appearance, IHasEntity<Item>
{
    public Item Entity { get; set; }
    [Column("Item")] public string EntityId { get; set; }
}
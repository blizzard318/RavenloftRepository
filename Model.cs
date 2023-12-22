using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RavenloftContext// : DbContext
{
    public HashSet<LocationAppearance> locationAppearances { get; set; }
    public HashSet<NPCAppearance> npcAppearances { get; set; }
    public HashSet<DomainAppearance> domainAppearances { get; set; }
    public HashSet<ItemAppearance> itemAppearances { get; set; }
    public HashSet<GroupAppearance> groupAppearances { get; set; }
    
    public HashSet<Relationship> Relationships { get; set; }

    public HashSet<Source> Sources { get; set; }
    public HashSet<Source.Trait> SourceTraits { get; set; }

    public HashSet<Trait> Traits { get; set; }

    public HashSet<Item> Items { get; set; }
    public HashSet<Domain> Domains { get; set; }
    public HashSet<NPC> NPCs { get; set; }
    public HashSet<Location> Locations { get; set; }
    public HashSet<Group> Groups { get; set; }

    /*public string DbPath { get; }
    public RavenloftContext() => DbPath = Path.Join(Directory.GetCurrentDirectory(), "Ravenloft.db");

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
        options.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
    }*/
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

public class Trait : UseName, IHasDomains, IHasLocations, IHasItems, IHasNPCs, IHasGroups
{
    public string Type { get; set; }
    public HashSet<Domain> Domains { get; set; } = new();
    public HashSet<Location> Locations { get; set; } = new();
    public HashSet<Item> Items { get; set; } = new();
    public HashSet<NPC> NPCs { get; set; } = new();
    public HashSet<Group> Groups { get; set; } = new();
}

public abstract class UseVariableName : UseName
{
    public string Name { get; set; } //Can be different in different sources
    public string OriginalName { get; set; } //For searching purposes
    public HashSet<Trait> Traits { get; set; } = new();
}
public class Domain : UseVariableName, IHasLocations, IHasItems, IHasNPCs, IHasGroups
{
    public HashSet<Location> Locations { get; set; } = new();
    public HashSet<NPC> NPCs { get; set; } = new();
    public HashSet<Item> Items { get; set; } = new();
    public HashSet<Group> Groups { get; set; } = new();
    //Recommended related media, recorded sessions
}
public class Location : UseVariableName, IHasDomains, IHasItems, IHasNPCs, IHasGroups
{
    public HashSet<Domain> Domains { get; set; } = new();
    public HashSet<NPC> NPCs { get; set; } = new();
    public HashSet<Item> Items { get; set; } = new();
    public HashSet<Group> Groups { get; set; } = new();
}
public class Item : UseVariableName, IHasDomains, IHasLocations, IHasNPCs, IHasGroups
{
    public HashSet<Domain> Domains { get; set; } = new();
    public HashSet<Location> Locations { get; set; } = new();
    public HashSet<NPC> NPCs { get; set; } = new();
    public HashSet<Group> Groups { get; set; } = new();
}
public class NPC : UseVariableName, IHasDomains, IHasLocations, IHasItems, IHasGroups
{
    public HashSet<Domain> Domains { get; set; } = new();
    public HashSet<Location> Locations { get; set; } = new();
    public HashSet<Item> Items { get; set; } = new();
    public HashSet<Group> Groups { get; set; } = new();

    public HashSet<Relationship> Relationships { get; set; } = new ();
    public HashSet<Relationship> IgnoreThis { get; set; } = new ();
    //string Damnation; //Event that damned them to their own Domain
    //string Curse; //What do they have to live with
    //string ClosedBorders; //When they close the borders, how does it manifest
}
public class Group : UseVariableName, IHasDomains, IHasLocations, IHasItems, IHasNPCs
{
    public HashSet<Domain> Domains { get; set; } = new();
    public HashSet<NPC> NPCs { get; set; } = new();
    public HashSet<Location> Locations { get; set; } = new();
    public HashSet<Item> Items { get; set; } = new();
}
public class Relationship
{
    public int Id { get; set; }
    public string PrimaryName { get; set; }
    public NPC Primary { get; set; }
    public string OtherName { get; set; }
    public NPC Other { get; set; } = new();
    public string RelationshipType { get; set; }
}
public abstract class Appearance
{
    public int Id { get; set; } //Auto-generated, ignore.
    public Source Source { get; set; }
    [Column("Source")] public string SourceKey { get; set; }
    public string PageNumbers { get; set; }
}
public class LocationAppearance : Appearance, IHasEntity<Location>
{
    public Location Entity { get; set; }
    [Column(nameof(Location))] public string EntityId { get; set; }
}
public class NPCAppearance : Appearance, IHasEntity<NPC>
{
    public NPC Entity { get; set; }
    [Column(nameof(NPC))] public string EntityId { get; set; }
}
public class DomainAppearance : Appearance, IHasEntity<Domain>
{
    public Domain Entity { get; set; }
    [Column(nameof(Domain))] public string EntityId { get; set; }
}
public class ItemAppearance : Appearance, IHasEntity<Item>
{
    public Item Entity { get; set; }
    [Column(nameof(Item))] public string EntityId { get; set; }
}
public class GroupAppearance : Appearance, IHasEntity<Group>
{
    public Group Entity { get; set; }
    [Column(nameof(Group))] public string EntityId { get; set; }
}
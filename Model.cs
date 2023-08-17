using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RavenloftContext : DbContext
{
    public DbSet<Appearance> Appearances { get; set; }
    public DbSet<Domain> Domains { get; set; }
    public DbSet<Trait> Traits { get; set; }
    public DbSet<Source> Sources { get; set; }
    public DbSet<Mistway> Mistways { get; set; }
    public DbSet<Cluster> Clusters { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<NPC> NPCs { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Relationship> Relationships { get; set; }
    public string DbPath { get; }
    public RavenloftContext() => DbPath = Path.Join(Directory.GetCurrentDirectory(), "Ravenloft.db");

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
        options.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Relationship>().Property(e => e.Type).HasConversion(
            v => v.ToString(),
            v => (Relationship.RelationshipType)Enum.Parse(typeof(Relationship.RelationshipType), v)
        );
        /*modelBuilder.Entity<Domain>().ToTable(nameof(Domain));
        //modelBuilder.Entity<DomainTrait>().ToTable("Domain Trait");
        modelBuilder.Entity<Source>().ToTable(nameof(Source));
        modelBuilder.Entity<Mistway>().ToTable(nameof(Mistway));
        modelBuilder.Entity<Cluster>().ToTable(nameof(Cluster));
        modelBuilder.Entity<Location>().ToTable(nameof(Location));
        //modelBuilder.Entity<LocationTrait>().ToTable("Location Trait");
        modelBuilder.Entity<Item>().ToTable(nameof(Item));
        //modelBuilder.Entity<ItemTrait>().ToTable("Item Trait");
        modelBuilder.Entity<NPC>().ToTable(nameof(NPC));
        modelBuilder.Entity<CreatureTrait>().ToTable(nameof(CreatureTrait));
        modelBuilder.Entity<Event>().ToTable(nameof(Event));

        modelBuilder.Entity<Base>()
            .HasDiscriminator()
            .HasValue<Source.Trait>("Source Trait");
            .HasValue<Domain.Trait>("Domain Trait")
            .HasValue<Item.Trait>("Item Trait")
            .HasValue<Location.Trait>("Location Trait");*/
    }
}
public abstract class Base
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string URL => string.Concat(Name.Where(c => c != ':' && !char.IsWhiteSpace(c)));
    public string ExtraInfo { get; set; } = string.Empty;
    public string ExternalLinks { get; set; } = string.Empty;
    public Base() { }
    public Base(string name) => Name = name;
}
public class Trait : Base
{
    public Trait() { }
    public Trait(string name, string type) : base(name) { this.type = type; }
    public string type { get; set; }
}
public class Appearance<T> where T : Base //This doesn't have a base.
{
    public int Id { get; set; }
    public Source Source { get; set; }
    public Base Entity { get; set; }
    public string PageNumbers { get; set; }

    public Appearance() { }
    public Appearance(Source source, Trait entity, params int[] pageNumbers) : this(pageNumbers) => Cross.Add(Source = source, Entity = entity);
    public Appearance(Source source, Domain entity, params int[] pageNumbers) : this(pageNumbers) => Cross.Add(Source = source, Entity = entity);
    public Appearance (Source source, T entity, params int[] pageNumbers) : this(pageNumbers) => Cross.Add(Source = source, Entity = entity);
    private Appearance (params int[] pageNumbers)
    {
        if (pageNumbers.Length == 0) PageNumbers = "Throughout";
        else PageNumbers = string.Join(',', pageNumbers);
    }
}
public class Source : Base, HasMany<Domain>, HasMany<NPC>, HasMany<Cluster>, HasMany<Mistway>, HasMany<Location>, HasMany<Item>, HasMany<Trait>, HasMany<Language>, HasMany<Relationship>
{
    public Source() { }
    public Source(string name) : base(name) { }

    public List<Trait> Traits { get; set; } = new();//Potential Canon, Non-Canon
                                                            //(Module levels go into descript)
    //[1e/../5e/No Edition], [Comic/Module/Novel/Gamebook/Sourcebook/Magazine/Videogame/Boardgame]
    List<Trait> HasMany<Trait>.Values { get => Traits; set => Traits = value; }

    public List<Cluster> Clusters { get; set; } = new();
    List<Cluster> HasMany<Cluster>.Values { get => Clusters; set => Clusters = value; }

    public List<Mistway> Mistways { get; set; } = new();
    List<Mistway> HasMany<Mistway>.Values { get => Mistways; set => Mistways = value; }

    public List<Domain> Domains { get; set; } = new();
    List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

    public List<Location> Locations { get; set; } = new();
    List<Location> HasMany<Location>.Values { get => Locations; set => Locations = value; }

    public List<Item> Items { get; set; } = new();
    List<Item> HasMany<Item>.Values { get => Items; set => Items = value; }

    public List<NPC> NPCs { get; set; } = new();
    List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

    public List<Language> Languages { get; set; } = new();
    List<Language> HasMany<Language>.Values { get => Languages; set => Languages = value; }

    public List<Relationship> Relationships { get; set; } = new();
    List<Relationship> HasMany<Relationship>.Values { get => Relationships; set => Relationships = value; }

    [Column(TypeName= "Date")] public DateTime ReleaseDate { get; set; }
    public string Contributors { get; set; }
}
public class Domain : Base, HasMany<NPC>, HasMany<Location>, HasMany<Cluster>, HasMany<Mistway>, HasMany<Trait>, HasMany<Item>, HasMany<Language>
{
    public Domain() { }
    public Domain(string name) : base(name) { }

    public List<Cluster> Clusters { get; set; }
    List<Cluster> HasMany<Cluster>.Values { get => Clusters; set => Clusters = value; }

    public List<Mistway> Mistways { get; set; } = new();
    List<Mistway> HasMany<Mistway>.Values { get => Mistways; set => Mistways = value; }

    public List<Location> Locations { get; set; } = new();
    List<Location> HasMany<Location>.Values { get => Locations; set => Locations = value; }

    public List<NPC> NPCs { get; set; } = new();
    List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

    public List<Trait> Traits { get; set; } = new();
    List<Trait> HasMany<Trait>.Values { get => Traits; set => Traits = value; }

    public List<Item> Items { get; set; } = new();
    List<Item> HasMany<Item>.Values { get => Items; set => Items = value; }

    public List<Language> Languages { get; set; } = new();
    List<Language> HasMany<Language>.Values { get => Languages; set => Languages = value; }
}
public class Mistway : Base, HasMany<Domain>
{
    public Mistway() { }
    public Mistway(string name) : base(name) { }

    public List<Domain> Domains { get; set; } = new();
    List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }
}
public class Cluster : Base, HasMany<Domain>
{
    public Cluster() { }
    public Cluster(string name) : base(name) { }

    public List<Domain> Domains { get; set; } = new();
    List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }
}
public class Location : Base, HasMany<Domain>, HasMany<NPC>, HasMany<Item>, HasMany<Trait>
{
    public Location() { }
    public Location(string name) : base(name) { }

    public List<Domain> Domains { get; set; } = new();//Place can get absorbed into other domains
    List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

    public List<NPC> NPCs { get; set; } = new();
    List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

    public List<Item> Items { get; set; } = new();
    List<Item> HasMany<Item>.Values { get => Items; set => Items = value; }

    public List<Trait> Traits { get; set; } = new();
    List<Trait> HasMany<Trait>.Values { get => Traits; set => Traits = value; }
    //public string Population { get; set; } //Maybe a number would be better
}
public class Item : Base, HasMany<Domain>, HasMany<Trait>, HasMany<Location>, HasMany<NPC>
{
    public Item() { }
    public Item(string name) : base(name) { }

    public List<Domain> Domains { get; set; } = new();
    List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

    public List<Trait> ItemTraits { get; set; } = new();
    List<Trait> HasMany<Trait>.Values { get => ItemTraits; set => ItemTraits = value; }

    public List<Location> Locations { get; set; } = new();
    List<Location> HasMany<Location>.Values { get => Locations; set => Locations = value; }

    public List<NPC> NPCs { get; set; } = new();
    List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }
}
public class NPC : Base, HasMany<Domain>, HasMany<Trait>, HasMany<Location>, HasMany<Language>
{
    public NPC() { }
    public NPC(string name) : base(name) { }

    //public string Damnation; //Event that damned them to their own Domain
    //public string Curse; //What do they have to live with
    //public string ClosedBorders; //When they close the borders, how does it manifest
    public List<Domain> Domains { get; set; } = new();//Place can get absorbed into other domains
    List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

    public List<Trait> CreatureTraits { get; set; } = new();
    List<Trait> HasMany<Trait>.Values { get => CreatureTraits; set => CreatureTraits = value; }//Like is he a gnome, darklord, vampire

    public List<Location> Locations { get; set; } = new();
    List<Location> HasMany<Location>.Values { get => Locations; set => Locations = value; } //Some people travel

    public List<Language> Languages { get; set; } = new();
    List<Language> HasMany<Language>.Values { get => Languages; set => Languages = value; }
}
public class Language : Base, HasMany<NPC>, HasMany<Domain>
{
    public Language() { }
    public Language(string name) : base(name) { }

    public List<NPC> NPCs { get; set; } = new();
    List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

    public List<Domain> Domains { get; set; } = new();
    List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }
}
public class Relationship : HasOne<Source>
{
    public int Id { get; set; }
    public NPC First { get; set; }
    public NPC Second { get; set; }
    public enum RelationshipType { Parent, Child, Spouse }
    public RelationshipType Type { get; set; }

    public Source Source { get; set; }
    Source HasOne<Source>.Value { get => Source; set => Source = value; }

    public Relationship() { }
    public Relationship(NPC first, NPC second, RelationshipType type) 
    {
        First = first;
        Second = second;
        Type = type;
    }
}
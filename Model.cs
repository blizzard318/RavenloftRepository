using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ravenloft
{
    public class RavenloftContext : DbContext
    {
        public DbSet<Canon> Canons { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<Mistway> Mistways { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemTrait> ItemTraits { get; set; }
        public DbSet<NPC> NPCs { get; set; }
        public DbSet<CreatureTrait> CreatureTraits { get; set; }
        public string DbPath { get; }
        public RavenloftContext() => DbPath = Path.Join(Directory.GetCurrentDirectory(), "Ravenloft.db");

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Source>().Property(e => e.Type).HasConversion(
                v => v.ToString(),
                v => (Source.SourceType)Enum.Parse(typeof(Source.SourceType), v)
            );
        }
    }
    public abstract class Base
    {
        [Key] public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public Base() { }
        public Base(string name) => Name = name;
    }
    public class Canon : Base, HasMany<Cluster>, HasMany<Domain>, HasMany<Mistway>, HasMany<Source>, HasMany<Location>, HasMany<Item>, HasMany<ItemTrait>, HasMany<NPC>, HasMany<CreatureTrait>
    {
        public Canon() { }
        public Canon(string name) : base(name) { }
        public List<Cluster> Clusters { get; set; } = new();
        List<Cluster> HasMany<Cluster>.Values { get => Clusters; set => Clusters = value; }

        public List<Domain> Domains { get; set; } = new();
        List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

        public List<Mistway> Mistways { get; set; } = new();
        List<Mistway> HasMany<Mistway>.Values { get => Mistways; set => Mistways = value; }

        public List<Location> Locations { get; set; } = new();
        List<Location> HasMany<Location>.Values { get => Locations; set => Locations = value; }

        public List<Item> Items { get; set; } = new();
        List<Item> HasMany<Item>.Values { get => Items; set => Items = value; }

        public List<ItemTrait> ItemTraits { get; set; } = new();
        List<ItemTrait> HasMany<ItemTrait>.Values { get => ItemTraits; set => ItemTraits = value; }

        public List<NPC> NPCs { get; set; } = new();
        List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

        public List<CreatureTrait> CreatureTraits { get; set; } = new();
        List<CreatureTrait> HasMany<CreatureTrait>.Values { get => CreatureTraits; set => CreatureTraits = value; }

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }
    }
    public class Cluster : Base, HasOne<Canon>, HasMany<Domain>, HasMany<Mistway>, HasMany<Source>
    {
        public Cluster() { }
        public Cluster(string name) : base(name) { }

        public Canon Canon { get; set; }
        Canon HasOne<Canon>.Value { get => Canon; set => Canon = value; }

        public List<Domain> Domains { get; set; } = new();
        List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

        public List<Mistway> Mistways { get; set; } = new();
        List<Mistway> HasMany<Mistway>.Values { get => Mistways; set => Mistways = value; }

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }
    }
    public class Domain : Base, HasOne<Canon>, HasMany<Edition>, HasMany<Location>, HasMany<NPC>, HasMany<Mistway>, HasMany<Source>
    {
        public Domain() { }
        public Domain(params string[] names) : base(names[0]) => Names = string.Join(',', names);
        public string Names { get; set; }

        public Canon Canon { get; set; }
        Canon HasOne<Canon>.Value { get => Canon; set => Canon = value; }

        public List<Edition> Editions { get; set; } = new();
        List<Edition> HasMany<Edition>.Values { get => Editions; set => Editions = value; }

        public List<Location> Locations { get; set; } = new();
        List<Location> HasMany<Location>.Values { get => Locations; set => Locations = value; }

        public List<NPC> NPCs { get; set; } = new();
        List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

        public List<Mistway> Mistways { get; set; } = new();
        List<Mistway> HasMany<Mistway>.Values { get => Mistways; set => Mistways = value; }

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }

        public string ClosedBorders { get; set; } = string.Empty;
        //public string Size { get; set; }
        //public List<Item> MistTalismans { get; set; } = new List<Item>();
        //public List<NPC> Darklords { get; set; } = new List<NPC>();
    }
    public class Mistway : Base, HasOne<Canon>, HasMany<Domain>, HasMany<Source>
    {
        public Mistway() { }
        public Mistway(string name) : base(name) { }

        public Canon Canon { get; set; }
        Canon HasOne<Canon>.Value { get => Canon; set => Canon = value; }

        public List<Domain> Domains { get; set; } = new();
        List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }
    }
    public class Edition : Base, HasMany<Domain>, HasMany<NPC>, HasMany<Item>, HasMany<CreatureTrait>, HasMany<Source>
    {
        public Edition() { }
        public Edition(string name) : base(name) { }

        public List<Domain> Domains { get; set; } = new();
        List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

        public List<NPC> NPCs { get; set; } = new();
        List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

        public List<Item> Items { get; set; } = new();
        List<Item> HasMany<Item>.Values { get => Items; set => Items = value; }

        public List<CreatureTrait> CreatureTraits { get; set; } = new();
        List<CreatureTrait> HasMany<CreatureTrait>.Values { get => CreatureTraits; set => CreatureTraits = value; }

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }
    }
    public class Source : Base, HasOne<Canon>, HasOne<Edition>, HasMany<Cluster>, HasMany<Domain>, HasMany<Mistway>, HasMany<Location>, HasMany<Item>, HasMany<ItemTrait>, HasMany<NPC>, HasMany<CreatureTrait>
    {
        public Source() { }
        public Source(string name) : base(name) { }
        public Canon Canon { get; set; }
        Canon HasOne<Canon>.Value { get => Canon; set => Canon = value; }

        public Edition Edition { get; set; }
        Edition HasOne<Edition>.Value { get => Edition; set => Edition = value; }

        public List<Cluster> Clusters { get; set; } = new();
        List<Cluster> HasMany<Cluster>.Values { get => Clusters; set => Clusters = value; }

        public List<Domain> Domains { get; set; } = new();
        List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

        public List<Mistway> Mistways { get; set; } = new();
        List<Mistway> HasMany<Mistway>.Values { get => Mistways; set => Mistways = value; }

        public List<Location> Locations { get; set; } = new();
        List<Location> HasMany<Location>.Values { get => Locations; set => Locations = value; }

        public List<Item> Items { get; set; } = new();
        List<Item> HasMany<Item>.Values { get => Items; set => Items = value; }

        public List<ItemTrait> ItemTraits { get; set; } = new();
        List<ItemTrait> HasMany<ItemTrait>.Values { get => ItemTraits; set => ItemTraits = value; }

        public List<NPC> NPCs { get; set; } = new();
        List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

        public List<CreatureTrait> CreatureTraits { get; set; } = new();
        List<CreatureTrait> HasMany<CreatureTrait>.Values { get => CreatureTraits; set => CreatureTraits = value; }

        public enum SourceType { Comic, Module, Novel, Gamebook, Sourcebook, Magazine, Videogame, Boardgame };
        public SourceType Type { get; set; }
        public string Notes { get; set; } //Like Levels
        public string ReleaseDate { get; set; }
        public string Contributors { get; set; }
    }
    public class Location : Base, HasOne<Canon>, HasOne<Domain>, HasMany<Edition>, HasMany<Location>, HasMany<NPC>, HasMany<CreatureTrait>, HasMany<Item>, HasMany<Source>
    {
        public Location() { }
        public Location(string name) : base(name) { }

        public Canon Canon { get; set; }
        Canon HasOne<Canon>.Value { get => Canon; set => Canon = value; }

        public Domain Domain { get; set; }
        Domain HasOne<Domain>.Value { get => Domain; set => Domain = value; }

        public List<Edition> Editions { get; set; } = new();
        List<Edition> HasMany<Edition>.Values { get => Editions; set => Editions = value; }

        public List<Location> Related { get; set; } = new();
        List<Location> HasMany<Location>.Values { get => Related; set => Related = value; }

        public List<NPC> NPCs { get; set; } = new();
        List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

        public List<CreatureTrait> CreatureTraits { get; set; } = new();
        List<CreatureTrait> HasMany<CreatureTrait>.Values { get => CreatureTraits; set => CreatureTraits = value; }

        public List<Item> Items { get; set; } = new();
        List<Item> HasMany<Item>.Values { get => Items; set => Items = value; }

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }

        public string Type { get; set; } //Like is it a town/city/cave/temple
        //public string Population { get; set; } //Maybe a number would be better?
    }
    public class Item : Base, HasMany<Edition>, HasMany<Domain>, HasMany<ItemTrait>, HasMany<Location>, HasMany<NPC>, HasMany<Source>
    {
        public Item() { }
        public Item(string name) : base(name) { }
        public List<Edition> Editions { get; set; } = new();
        List<Edition> HasMany<Edition>.Values { get => Editions; set => Editions = value; }

        public List<Domain> Domains { get; set; } = new();
        List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

        public List<ItemTrait> ItemTraits { get; set; } = new();
        List<ItemTrait> HasMany<ItemTrait>.Values { get => ItemTraits; set => ItemTraits = value; }

        public List<Location> Locations { get; set; } = new();
        List<Location> HasMany<Location>.Values { get => Locations; set => Locations = value; }

        public List<NPC> NPCs { get; set; } = new();
        List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }
    }
    public class ItemTrait : Base, HasMany<Item>
    {
        public ItemTrait() { }
        public ItemTrait(string name) : base(name) { }

        public List<Item> Items { get; set; } = new();
        List<Item> HasMany<Item>.Values { get => Items; set => Items = value; }
    }
    /*public class Relationship
    {
        [Key] public string Name { get; set; }
        public NPC Primary { get; set; } //Main person, Like Father to List<NPC>
        public List<NPC> NPCs { get; set; } //List of NPCs who belong
        public List<CreatureTrait> CreatureTraits { get; set; } //Shared/Affiliated traits
    }*/
    public class NPC : Base, HasMany<Edition>, HasMany<Domain>, HasMany<CreatureTrait>, HasMany<Location>, HasMany<Source>
    {
        public NPC() { }
        public NPC(params string[] names) : base(names[0]) => Aliases = string.Join(',', names);

        public List<Edition> Editions { get; set; } = new();
        List<Edition> HasMany<Edition>.Values { get => Editions; set => Editions = value; }

        public List<Domain> Domains { get; set; } = new();
        List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; } //People travel

        public List<CreatureTrait> CreatureTraits { get; set; } = new();
        List<CreatureTrait> HasMany<CreatureTrait>.Values { get => CreatureTraits; set => CreatureTraits = value; }//Like is he a gnome, darklord, vampire

        public List<Location> Locations { get; set; } = new();
        List<Location> HasMany<Location>.Values { get => Locations; set => Locations = value; } //Some people travel

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }
        public string Aliases { get; set; }
    }
    public class CreatureTrait : Base, HasMany<NPC>, HasMany<Domain>, HasMany<Location>, HasMany<Source>
    {
        public CreatureTrait() { }
        public CreatureTrait(string name) : base(name) { }

        public List<NPC> NPCs { get; set; } = new();
        List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

        public List<Domain> Domains { get; set; } = new();
        List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

        public List<Location> Locations { get; set; } = new();
        List<Location> HasMany<Location>.Values { get => Locations; set => Locations = value; }

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }
    }
}
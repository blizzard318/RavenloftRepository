using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ravenloft
{
    public class RavenloftContext : DbContext
    {
        public DbSet<Source> Sources { get; set; }
        public string DbPath { get; }
        public RavenloftContext() => DbPath = Path.Join(Directory.GetCurrentDirectory(), "Ravenloft.db");

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NPC>().ToTable("NPCs");
            modelBuilder.Entity<Darklord>().ToTable("Darklords");
        }
    }
    public abstract class Base
    {
        [Key] public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public Base() { }
        public Base(string name) => Name = name;
    }
    public class Source : Base, HasMany<Cluster>, HasMany<Domain>, HasMany<Mistway>, HasMany<Location>, HasMany<Item>, HasMany<Darklord>,HasMany<NPC>, HasMany<CreatureTrait>
    {
        public Source() { }
        public Source(string name) : base(name) { }
        public List<string> SourceTraits { get; set; } = new();//Potential Canon, Non-Canon, Levels if Module
        //[1e/../5e/No Edition], [Comic/Module/Novel/Gamebook/Sourcebook/Magazine/Videogame/Boardgame]
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

        public List<Darklord> Darklords { get; set; } = new();
        List<Darklord> HasMany<Darklord>.Values { get => Darklords; set => Darklords = value; }

        public List<NPC> NPCs { get; set; } = new();
        List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

        public List<CreatureTrait> CreatureTraits { get; set; } = new();
        List<CreatureTrait> HasMany<CreatureTrait>.Values { get => CreatureTraits; set => CreatureTraits = value; }

        public DateTime ReleaseDate { get; set; }
        public string Contributors { get; set; }
    }
    public class Domain : Base, HasMany<Location>, HasMany<Cluster>, HasMany<Darklord>, HasMany<NPC>, HasMany<Mistway>, HasMany<Source>, HasMany<Domain.Trait>
    {
        public Domain() { }
        public Domain(params string[] names) : base(names[0]) => Names = string.Join('/', names);
        public string Names { get; set; }

        public List<Cluster> Clusters { get; set; }
        List<Cluster> HasMany<Cluster>.Values { get => Clusters; set => Clusters = value; }

        public List<Location> Locations { get; set; } = new();
        List<Location> HasMany<Location>.Values { get => Locations; set => Locations = value; }

        public List<Darklord> Darklords { get; set; } = new();
        List<Darklord> HasMany<Darklord>.Values { get => Darklords; set => Darklords = value; }

        public List<NPC> NPCs { get; set; } = new();
        List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

        public List<Mistway> Mistways { get; set; } = new();
        List<Mistway> HasMany<Mistway>.Values { get => Mistways; set => Mistways = value; }

        public List<Trait> DomainTraits { get; set; } = new();
        List<Trait> HasMany<Trait>.Values { get => DomainTraits; set => DomainTraits = value; }

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }
        //public string Size { get; set; }
        //public List<Item> MistTalismans { get; set; } = new List<Item>();
        //public List<NPC> Darklords { get; set; } = new List<NPC>();
        public class Trait : Base, HasMany<Domain>
        {
            public Trait() { }
            public Trait(string name) : base(name) { }

            public List<Domain> Domains { get; set; } = new();
            List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }
        }
    }
    public class Mistway : Base, HasMany<Domain>, HasMany<Source>
    {
        public Mistway() { }
        public Mistway(string name) : base(name) { }

        public List<Domain> Domains { get; set; } = new();
        List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }
    }
    public class Cluster : Base, HasMany<Domain>, HasMany<Source>
    {
        public Cluster() { }
        public Cluster(string name) : base(name) { }

        public List<Domain> Domains { get; set; } = new();
        List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }
    }
    public class Location : Base, HasOne<Domain>, HasMany<Location>, HasMany<NPC>, HasMany<CreatureTrait>, HasMany<Item>, HasMany<Source>, HasMany<Location.Trait>
    {
        public Location() { }
        public Location(string name) : base(name) { }

        public Domain Domain { get; set; }
        Domain HasOne<Domain>.Value { get => Domain; set => Domain = value; }

        public List<Location> Related { get; set; } = new();
        List<Location> HasMany<Location>.Values { get => Related; set => Related = value; }

        public List<NPC> NPCs { get; set; } = new();
        List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

        public List<CreatureTrait> CreatureTraits { get; set; } = new();
        List<CreatureTrait> HasMany<CreatureTrait>.Values { get => CreatureTraits; set => CreatureTraits = value; }

        public List<Item> Items { get; set; } = new();
        List<Item> HasMany<Item>.Values { get => Items; set => Items = value; }

        public List<Trait> LocationTraits { get; set; } = new();
        List<Trait> HasMany<Trait>.Values { get => LocationTraits; set => LocationTraits = value; }

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }

        public string Type { get; set; } //Like is it a town/city/cave/temple
        //public string Population { get; set; } //Maybe a number would be better

        public class Trait : Base, HasMany<Location>
        {
            public Trait() { }
            public Trait(string name) : base(name) { }

            public List<Location> Locations { get; set; } = new();
            List<Location> HasMany<Location>.Values { get => Locations; set => Locations = value; }
        }
    }
    public class Item : Base, HasMany<Domain>, HasMany<Item.Trait>, HasMany<Location>, HasMany<NPC>, HasMany<Source>
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

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }

        public class Trait : Base, HasMany<Item>
        {
            public Trait() { }
            public Trait(string name) : base(name) { }

            public List<Item> Items { get; set; } = new();
            List<Item> HasMany<Item>.Values { get => Items; set => Items = value; }
        }
    }
    /*public class Relationship
    {
        [Key] public string Name { get; set; }
        public NPC Primary { get; set; } //Main person, Like Father to List<NPC>
        public List<NPC> NPCs { get; set; } //List of NPCs who belong
        public List<CreatureTrait> CreatureTraits { get; set; } //Shared/Affiliated traits
    }*/
    public class Darklord : NPC
    {
        public Darklord() { }
        public Darklord(params string[] names) : base(names) { }
        public string Damnation { get; set; } = string.Empty; //Event that damned them to their own Domain
        public string Curse { get; set;} = string.Empty; //What do they have to live with
        public string ClosedBorders { get; set; } = string.Empty; //When they close the borders, how does it manifest
    }
    public class NPC : Base, HasOne<Domain>, HasMany<CreatureTrait>, HasMany<Location>, HasMany<Source>
    {
        public NPC() { }
        public NPC(params string[] names) : base(names[0]) => Aliases = string.Join(',', names);

        public Domain Residence { get; set; }
        Domain HasOne<Domain>.Value { get => Residence; set => Residence = value; }

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
    public class Event : Base, HasMany<NPC>, HasMany<Darklord>, HasMany<Item>, HasMany<Domain>, HasMany<Location>, HasMany<Source>
    {
        public Event() { }
        public Event(string name) : base(name) { }

        public string Date {  get; set; }

        public List<NPC> NPCs { get; set; } = new();
        List<NPC> HasMany<NPC>.Values { get => NPCs; set => NPCs = value; }

        public List<Darklord> Darklords { get; set; } = new();
        List<Darklord> HasMany<Darklord>.Values { get => Darklords; set => Darklords = value; }

        public List<Domain> Domains { get; set; } = new();
        List<Domain> HasMany<Domain>.Values { get => Domains; set => Domains = value; }

        public List<Location> Locations { get; set; } = new();
        List<Location> HasMany<Location>.Values { get => Locations; set => Locations = value; }

        public List<Item> Items { get; set; } = new();
        List<Item> HasMany<Item>.Values { get => Items; set => Items = value; }

        public List<Source> Sources { get; set; } = new();
        List<Source> HasMany<Source>.Values { get => Sources; set => Sources = value; }
    }
}
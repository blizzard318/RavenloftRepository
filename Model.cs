using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ravenloft
{
    public class RavenloftContext : DbContext
    {
        public DbSet<Canon> Canons { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<Mistway> Mistways { get; set; }
        public DbSet<Edition> Editions { get; set; }
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
    }
    public abstract class Base
    {
        [Key] public string Name { get; set; }
        public string? Description { get; set; } = string.Empty;
        public Base() { }
        public Base(string name) => Name = name;
    }
    public class Canon : Base, HasMany<Cluster>, HasMany<Domain>, HasMany<Mistway>, HasMany<Source>, HasMany<Location>, HasMany<Item>, HasMany<ItemTrait>, HasMany<NPC>, HasMany<CreatureTrait>
    {
        public Canon() { }
        public Canon(string name) : base(name) { }
        [Column("Clusters")] List<Cluster> HasMany<Cluster>.Values { get; set; } = new();
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; } = new();
        [Column("Mistways")] List<Mistway> HasMany<Mistway>.Values { get; set; } = new();
        [Column("Locations")] List<Location> HasMany<Location>.Values { get; set; } = new();
        [Column("Items")] List<Item> HasMany<Item>.Values { get; set; } = new();
        [Column("ItemTraits")] List<ItemTrait> HasMany<ItemTrait>.Values { get; set; } = new();
        [Column("NPCs")] List<NPC> HasMany<NPC>.Values { get; set; } = new();   
        [Column("CreatureTraits")] List<CreatureTrait> HasMany<CreatureTrait>.Values { get; set; } = new();
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; } = new();
    }
    public class Cluster : Base, HasOne<Canon>, HasMany<Domain>, HasMany<Mistway>, HasMany<Source>
    {
        public Cluster() { }
        public Cluster(string name) : base(name) { }
        [Column("Canon")] Canon HasOne<Canon>.Value { get; set; } = new();
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; } = new();
        [Column("Mistways")] List<Mistway> HasMany<Mistway>.Values { get; set; } = new();
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; } = new();
    }
    public class Domain : Base, HasOne<Canon>, HasMany<Edition>, HasMany<Location>, HasMany<NPC>, HasMany<Mistway>, HasMany<Source>
    {
        public Domain() { }
        public Domain(params string[] names) : base(names[0]) => Names = string.Join(',', names);
        [Column("Names")] public string Names { get; set; }
        [Column("Canon")] Canon HasOne<Canon>.Value { get; set; } = new();
        [Column("Editions")] List<Edition> HasMany<Edition>.Values { get; set; } = new();
        [Column("Locations")] List<Location> HasMany<Location>.Values { get; set; } = new();
        [Column("NPCs")] List<NPC> HasMany<NPC>.Values { get; set; } = new();
        [Column("Mistways")] List<Mistway> HasMany<Mistway>.Values { get; set; } = new();   
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; } = new();
        public string? ClosedBorders { get; set; } = string.Empty;
        //public string Size { get; set; }
        //public List<Item> MistTalismans { get; set; } = new List<Item>();
        //public List<NPC> Darklords { get; set; } = new List<NPC>();
    }
    public class Mistway : Base, HasOne<Canon>, HasMany<Domain>, HasMany<Source>
    {
        public Mistway() { }
        public Mistway(string name) : base(name) { }
        [Column("Canon")] Canon HasOne<Canon>.Value { get; set; } = new();
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; } = new();
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; } = new();
    }
    public class Edition : Base, HasMany<Domain>, HasMany<NPC>, HasMany<Item>, HasMany<CreatureTrait>, HasMany<Source>
    {
        public Edition() { }
        public Edition(string name) : base(name) { }
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; } = new();
        [Column("NPCs")] List<NPC> HasMany<NPC>.Values { get; set; } = new();
        [Column("Items")] List<Item> HasMany<Item>.Values { get; set; } = new();
        [Column("Groups")] List<CreatureTrait> HasMany<CreatureTrait>.Values { get; set; } = new();
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; } = new();
    }
    public class Source : Base, HasOne<Canon>, HasOne<Edition>, HasMany<Cluster>, HasMany<Domain>, HasMany<Mistway>, HasMany<Location>, HasMany<Item>, HasMany<ItemTrait>, HasMany<NPC>, HasMany<CreatureTrait>
    {
        public Source() { }
        public Source(string name) : base(name) { }
        [Column("Canon")] Canon HasOne<Canon>.Value { get; set; } = new();
        [Column("Edition")] Edition HasOne<Edition>.Value { get; set; } = new();
        [Column("Clusters")] List<Cluster> HasMany<Cluster>.Values { get; set; } = new();
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; } = new();
        [Column("Mistways")] List<Mistway> HasMany<Mistway>.Values { get; set; } = new();
        [Column("Locations")] List<Location> HasMany<Location>.Values { get; set; } = new();
        [Column("Items")] List<Item> HasMany<Item>.Values { get; set; } = new();
        [Column("ItemTraits")] List<ItemTrait> HasMany<ItemTrait>.Values { get; set; } = new();
        [Column("NPCs")] List<NPC> HasMany<NPC>.Values { get; set; } = new();
        [Column("CreatureTraits")] List<CreatureTrait> HasMany<CreatureTrait>.Values { get; set; } = new();
        public enum SourceType { Comic, Module, Novel, Gamebook, Sourcebook, Magazine, Videogame, Boardgame };
        public SourceType Type { get; set; }
        public string Notes { get; set; } //Like Levels
        public string ReleaseDate { get; set; }
        public string Contributors { get; set; }
    }
    public class Location : Base, HasOne<Domain>, HasMany<Edition>, HasOne<Location>, HasMany<Location>, HasMany<NPC>, HasMany<CreatureTrait>, HasMany<Item>, HasMany<Source>
    {
        public Location() { }
        public Location(string name) : base(name) { }
        [Column("Domain")] Domain HasOne<Domain>.Value { get; set; } = new();
        [Column("Editions")] List<Edition> HasMany<Edition>.Values { get; set; } = new();
        [Column("PartOf")] Location HasOne<Location>.Value { get; set; } = new();
        [Column("Contains")] List<Location> HasMany<Location>.Values { get; set; } = new();
        [Column("NPCs")] List<NPC> HasMany<NPC>.Values { get; set; } = new();
        [Column("Creatures")] List<CreatureTrait> HasMany<CreatureTrait>.Values { get; set; } = new(); //Restrict to creatures
        [Column("Items")] List<Item> HasMany<Item>.Values { get; set; } = new();
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; } = new();
        public string? Type { get; set; } = string.Empty; //Like is it a town/city/cave/temple
        //public string? Population { get; set; } = string.Empty; //Maybe a number would be better?
    }
    public class Item : Base, HasMany<Edition>, HasMany<Domain>, HasMany<ItemTrait>, HasMany<Location>, HasMany<NPC>, HasMany<Source>
    {
        public Item() { }
        public Item(string name) : base(name) { }
        [Column("Editions")] List<Edition> HasMany<Edition>.Values { get; set; } = new();
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; } = new();
        [Column("Traits")] List<ItemTrait> HasMany<ItemTrait>.Values { get; set; } = new();
        [Column("Can be found in")] List<Location> HasMany<Location>.Values { get; set; } = new();
        [Column("Owners")] List<NPC> HasMany<NPC>.Values { get; set; } = new();
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; } = new();
    }
    public class ItemTrait : Base, HasMany<Item>
    {
        public ItemTrait() { }
        public ItemTrait(string name) : base(name) { }
        [Column("Items")] List<Item> HasMany<Item>.Values { get; set; } = new();
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
        [Column("Editions")] List<Edition> HasMany<Edition>.Values { get; set; } = new();
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; } = new(); //People travel
        [Column("CreatureTraits")] List<CreatureTrait> HasMany<CreatureTrait>.Values { get; set; } = new();//Like is he a gnome, darklord, vampire
        [Column("Locations")] List<Location> HasMany<Location>.Values { get; set; } = new(); //Some people travel
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; } = new();
        public string Aliases { get; set; }
    }
    public class CreatureTrait : Base, HasMany<NPC>, HasMany<Domain>, HasMany<Location>, HasMany<Source>
    {
        public CreatureTrait() { }
        public CreatureTrait(string name) : base(name) { }
        [Column("NPCs")] List<NPC> HasMany<NPC>.Values { get; set; } = new();
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; } = new();
        [Column("Locations")] List<Location> HasMany<Location>.Values { get; set; } = new();
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; } = new();
    }
}
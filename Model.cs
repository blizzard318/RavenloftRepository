using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

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
        public DbSet<Group> Groups { get; set; }
        public DbSet<CreatureTrait> CreatureTraits { get; set; }
        public DbSet<ItemTrait> ItemTraits { get; set; }
        public DbSet<Creature> Creatures { get; set; }
        public string DbPath { get; }
        public RavenloftContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "Ravenloft.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
    public class Canon : HasMany<Cluster>, HasMany<Domain>, HasMany<Mistway>, HasMany<Source>, HasMany<Location>, HasMany<Item>, HasMany<ItemTrait>, HasMany<Group>, HasMany<NPC>, HasMany<CreatureTrait>, HasMany<Creature>
    {
        [Key] public string Name { get; set; }
        [Column("Clusters")] List<Cluster> HasMany<Cluster>.Values { get; set; }
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; }
        [Column("Mistways")] List<Mistway> HasMany<Mistway>.Values { get; set; }
        [Column("Locations")] List<Location> HasMany<Location>.Values { get; set; }
        [Column("Items")] List<Item> HasMany<Item>.Values { get; set; }
        [Column("ItemTraits")] List<ItemTrait> HasMany<ItemTrait>.Values { get; set; }
        [Column("Groups")] List<Group> HasMany<Group>.Values { get; set; }
        [Column("NPCs")] List<NPC> HasMany<NPC>.Values { get; set; }
        [Column("CreatureTraits")] List<CreatureTrait> HasMany<CreatureTrait>.Values { get; set; }
        [Column("Creatures")] List<Creature> HasMany<Creature>.Values { get; set; }
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; }
    }
    public class Cluster : HasOne<Canon>, HasMany<Domain>, HasMany<Mistway>, HasMany<Source>
    {
        [Key] public string Name { get; set; }
        [Column("Canon")] Canon HasOne<Canon>.Value { get; set; }
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; }
        [Column("Mistways")] List<Mistway> HasMany<Mistway>.Values { get; set; }
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; }
    }
    public class Domain : HasOne<Canon>, HasMany<Edition>, HasMany<Location>, HasMany<Group>, HasMany<NPC>, HasMany<Mistway>, HasMany<Source>
    {
        [Key] public string Name { get; set; }
        [Column("Canon")] Canon HasOne<Canon>.Value { get; set; }
        [Column("Editions")] List<Edition> HasMany<Edition>.Values { get; set; }
        [Column("Locations")] List<Location> HasMany<Location>.Values { get; set; }
        [Column("Groups")] List<Group> HasMany<Group>.Values { get; set; }
        [Column("NPCs")] List<NPC> HasMany<NPC>.Values { get; set; }
        [Column("Mistways")] List<Mistway> HasMany<Mistway>.Values { get; set; }
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; }
        public string ClosedBorders { get; set; }
        //public string Size { get; set; }
        //public List<Item> MistTalismans { get; set; } = new List<Item>();
        //public List<NPC> Darklords { get; set; } = new List<NPC>();
    }
    public class Mistway : HasOne<Canon>, HasMany<Domain>, HasMany<Source>
    {
        [Key] public string Name { get; set; }
        [Column("Canon")] Canon HasOne<Canon>.Value { get; set; }
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; }
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; }
    }
    public class Edition : HasMany<Domain>, HasMany<Creature>, HasMany<NPC>, HasMany<Item>, HasMany<CreatureTrait>, HasMany<Source>
    {
        [Key] public string Name { get; set; }
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; }
        [Column("Creatures")] List<Creature> HasMany<Creature>.Values { get; set; }
        [Column("NPCs")] List<NPC> HasMany<NPC>.Values { get; set; }
        [Column("Items")] List<Item> HasMany<Item>.Values { get; set; }
        [Column("Groups")] List<CreatureTrait> HasMany<CreatureTrait>.Values { get; set; }
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; }
    }
    public class Source : HasOne<Canon>, HasOne<Edition>, HasMany<Cluster>, HasMany<Domain>, HasMany<Mistway>, HasMany<Location>, HasMany<Item>, HasMany<ItemTrait>, HasMany<NPC>, HasMany<CreatureTrait>, HasMany<Creature>
    {
        [Key] public string Name { get; set; }
        [Column("Canon")] Canon HasOne<Canon>.Value { get; set; }
        [Column("Edition")] Edition HasOne<Edition>.Value { get; set; }
        [Column("Clusters")] List<Cluster> HasMany<Cluster>.Values { get; set; }
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; }
        [Column("Mistways")] List<Mistway> HasMany<Mistway>.Values { get; set; }
        [Column("Locations")] List<Location> HasMany<Location>.Values { get; set; }
        [Column("Items")] List<Item> HasMany<Item>.Values { get; set; }
        [Column("ItemTraits")] List<ItemTrait> HasMany<ItemTrait>.Values { get; set; }
        [Column("NPCs")] List<NPC> HasMany<NPC>.Values { get; set; }
        [Column("CreatureTraits")] List<CreatureTrait> HasMany<CreatureTrait>.Values { get; set; }
        [Column("Creatures")] List<Creature> HasMany<Creature>.Values { get; set; }
        public enum SourceType { Comic, Module, Novel, Gamebook, Sourcebook, Magazine, Videogame, Boardgame };
        public SourceType Type { get; set; }
        public string Notes { get; set; } //Like Levels
        public string ReleaseDate { get; set; }
        public string Contributors { get; set; }
    }
    public class Location : HasOne<Domain>, HasMany<Edition>, HasOne<Location>, HasMany<Location>, HasMany<NPC>, HasMany<Creature>, HasMany<Item>, HasMany<Source>
    {
        [Key] public string Name { get; set; }
        [Column("Domain")] Domain HasOne<Domain>.Value { get; set; }
        [Column("Editions")] List<Edition> HasMany<Edition>.Values { get; set; }
        [Column("PartOf")] Location HasOne<Location>.Value { get; set; }
        [Column("Contains")] List<Location> HasMany<Location>.Values { get; set; }
        [Column("NPCs")] List<NPC> HasMany<NPC>.Values { get; set; }
        [Column("Creatures")] List<Creature> HasMany<Creature>.Values { get; set; }
        [Column("Items")] List<Item> HasMany<Item>.Values { get; set; }
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; }
        public string Type { get; set; } //Like is it a town/city/cave/temple
        public string Population { get; set; } //Maybe a number would be better?
        public string Description { get; set; }
    }
    public class Item : HasMany<Edition>, HasMany<Domain>, HasMany<ItemTrait>, HasMany<Location>, HasMany<Source>
    {
        [Key] public string Name { get; set; }
        [Column("Editions")] List<Edition> HasMany<Edition>.Values { get; set; }
        [Column("Domains")] List<Domain> HasMany<Domain>.Values { get; set; }
        [Column("Traits")] List<ItemTrait> HasMany<ItemTrait>.Values { get; set; }
        [Column("Contains")] List<Location> HasMany<Location>.Values { get; set; }
        [Column("Sources")] List<Source> HasMany<Source>.Values { get; set; }
    }
    public class ItemTrait : HasMany<Item>
    {
        [Key] public string Name { get; set; }
        [Column("Items")] List<Item> HasMany<Item>.Values { get; set; }
    }
    public class Relationship
    {
        [Key] public string Name { get; set; }
        public NPC Primary { get; set; } //Main person, Like Father to List<NPC>
        public List<NPC> NPCs { get; set; } //List of NPCs who belong
        public List<CreatureTrait> CreatureTraits { get; set; } //Shared/Affiliated traits
    }
    public class NPC
    {
        [Key] public string Name { get; set; }
        public List<Domain> Domains { get; set; } = new List<Domain>();//Some people travel
        public List<Edition> Editions { get; set; } = new List<Edition>();
        public List<CreatureTrait> Traits { get; set; } = new List<CreatureTrait>();//Like is he a gnome, darklord, vampire
        public List<Location> Locations { get; set; } = new List<Location>();//Some people travel
        public List<Source> Sources { get; set; } = new List<Source>();
        public string Aliases { get; set; }
    }
    public class CreatureTrait : HasOne<Canon>
    {
        [Key] public string Name { get; set; }
        public Canon Canon { get; set; } //Al-Kathos
        public List<NPC> NPCs { get; set; } = new List<NPC>();
    }
    public class Creature
    {
        [Key] public string Name { get; set; }
        public List<Domain> Domains { get; set; } = new List<Domain>();
        public List<Edition> Editions { get; set; } = new List<Edition>();
        public List<CreatureTrait> Traits { get; set; } = new List<CreatureTrait>(); //Like is he a gnome, darklord, vampire
        public List<Location> Locations { get; set; } = new List<Location>();
        public List<Source> Sources { get; set; } = new List<Source>();
    }
}
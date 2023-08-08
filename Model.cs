using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
    public interface HasCanon
    {
        public Canon Canon { get; set; }
    }
    public class Canon
    {
        [Key] public string Name { get; set; }
        public List<Cluster> Clusters { get; set; } = new List<Cluster>();
        public List<Domain> Domains { get; set; } = new List<Domain>();
        public List<Mistway> Mistways { get; set; } = new List<Mistway>();
        public List<Source> Sources { get; set; } = new List<Source>();
        public List<Location> Locations { get; set; } = new List<Location>();
        public List<Item> Items { get; set; } = new List<Item>();
        public List<ItemTrait> ItemTraits { get; set; } = new List<ItemTrait>();
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<NPC> NPCs { get; set; } = new List<NPC>();
        public List<CreatureTrait> CreatureTraits { get; set; } = new List<CreatureTrait>();
        public List<Creature> Creatures { get; set; } = new List<Creature>();
    }
    public class Cluster : HasCanon
    {
        [Key] public string Name { get; set; }
        public Canon Canon { get; set; }
        public List<Domain> Domains { get; set; } = new List<Domain>();
        public List<Mistway> Mistways { get; set; } = new List<Mistway>();
        public List<Source> Sources { get; set; } = new List<Source>();
    }
    public class Domain
    {
        [Key] public string Name { get; set; }
        public Canon Canon { get; set; }
        public List<Edition> Editions { get; set; } = new List<Edition>();
        public string Size { get; set; }
        public List<Item> MistTalismans { get; set; } = new List<Item>();
        public string ClosedBorders { get; set; }
        public List<Location> Locations { get; set; } = new List<Location>();
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<NPC> NPCs { get; set; } = new List<NPC>();
        public List<Mistway> Mistways { get; set; } = new List<Mistway>();
        public List<Source> Sources { get; set; } = new List<Source>();
    }
    public class Mistway
    {
        [Key] public string Name { get; set; }
        public Canon Canon { get; set; }
        public List<Domain> Domains { get; set; } = new List<Domain>();
        public List<Source> Sources { get; set; } = new List<Source>();
    }
    public class Edition
    {
        [Key] public string Name { get; set; }
        public List<Domain> Domains { get; set; } = new List<Domain>();
        public List<Creature> Creatures { get; set; } = new List<Creature>();
        public List<NPC> NPCs { get; set; } = new List<NPC>();
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<Source> Sources { get; set; } = new List<Source>();
    }
    public class Source
    {
        [Key] public string Name { get; set; }
        public Canon Canon { get; set; }
        public Edition Edition { get; set; }
        public enum SourceType { Comic, Module, Novel, Gamebook, Sourcebook, Magazine, Videogame, Boardgame };
        public SourceType Type { get; set; }
        public List<Cluster> Clusters { get; set; } = new List<Cluster>();
        public List<Domain> Domains { get; set; } = new List<Domain>();
        public List<Mistway> Mistways { get; set; } = new List<Mistway>();
        public List<Location> Locations { get; set; } = new List<Location>();
        public List<Item> Items { get; set; } = new List<Item>();
        public List<ItemTrait> ItemTraits { get; set; } = new List<ItemTrait>();
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<NPC> NPCs { get; set; } = new List<NPC>();
        public List<CreatureTrait> CreatureTraits { get; set; } = new List<CreatureTrait>();
        public List<Creature> Creatures { get; set; } = new List<Creature>();
    }
    public class IRLPerson
    {
        [Key] public string Name { get; set; }
        public string Roles { get; set; }
        public List<Source> Sources { get; set; } = new List<Source>();

    }
    public class Location
    {
        [Key] public string Name { get; set; }
        public Domain Domain { get; set; }
        public List<Edition> Editions { get; set; } = new List<Edition>();
        public string Type { get; set; } //Like is it a town/city/cave/temple
        public Location? PartOf { get; set; }
        public List<Location> Contains { get; set; } = new List<Location>();
        public string Population { get; set; } //Maybe a number would be better?
        public string Description { get; set; }
        public List<NPC> NPCs { get; set; } = new List<NPC>();
        public List<Creature> Creatures { get; set; } = new List<Creature>();
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Source> Sources { get; set; } = new List<Source>();
    }
    public class Item
    {
        [Key] public string Name { get; set; }
        public List<Domain> Domains { get; set; } = new List<Domain>();
        public List<ItemTrait> Traits { get; set; } = new List<ItemTrait>();
        public List<Location> Locations { get; set; } = new List<Location>();
        public List<Source> Sources { get; set; } = new List<Source>();
    }
    public class ItemTrait
    {
        [Key] public string Name { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
    public class Group
    {
        [Key] public string Name { get; set; }
        public Group? PartOf { get; set; }
        public List<Group> Contains { get; set; } = new List<Group>();
        public List<Source> Sources { get; set; } = new List<Source>();
    }
    public class NPC
    {
        [Key] public string Name { get; set; }
        public List<Domain> Domains { get; set; } = new List<Domain>();//Some people travel
        public List<Edition> Editions { get; set; } = new List<Edition>();
        public string Aliases { get; set; }
        public List<CreatureTrait> Traits { get; set; } = new List<CreatureTrait>();//Like is he a gnome, darklord, vampire
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<Location> Locations { get; set; } = new List<Location>();//Some people travel
        public List<Source> Sources { get; set; } = new List<Source>();
    }
    public class CreatureTrait
{
        [Key] public string Name { get; set; }
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
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ravenloft
{
    public class RavenloftContext : DbContext
    {
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

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }
    [Flags] public enum Canon { Canon = 1, Soft = 2, Netbook = 4, NonCanon = 8, Homebrew = 16 }

    public class Cluster
    {
        [Key] public string Name { get; set; }
        public Canon Canon { get; set; }
        public List<Domain> Domains { get; set; }
        public List<Mistway> Mistways { get; set; }
        public List<Source> Sources { get; set; }
    }
    public class Domain
    {
        [Key] public string Name { get; set; }
        public Canon Canon { get; set; }
        public List<Edition> Editions { get; set; }
        public string Size { get; set; }
        public List<NPC> Darklord { get; set; } //Don't forget, there can be more than one
        public List<Item> MistTalismans { get; set; }
        public string ClosedBorders { get; set; }
        public List<Location> Locations { get; set; }
        public List<Group> Groups { get; set; }
        public List<Source> Sources { get; set; }
    }
    public class Mistway
    {
        [Key] public string Name { get; set; }
        public Canon Canon { get; set; }
        public List<Domain> Domains { get; set; }
        public List<Source> Sources { get; set; }
    }
    public class Edition
    {
        [Key] public string Name { get; set; }
        public List<Domain> Domains { get; set; }
        public List<Creature> Creatures { get; set; }
        public List<NPC> NPCs { get; set; }
        public List<Item> Items { get; set; }
        public List<Group> Groups { get; set; }
        public List<Source> Sources { get; set; }
    }
    public class Source
    {
        public enum SourceType { Comic, Module, Novel, Gamebook, Sourcebook, Magazine, Videogame, Boardgame };
        public Canon Canon { get; set; }
        [Key] public string Name { get; set; }
        public Edition Edition { get; set; }
        public SourceType Type { get; set; }
        public List<Domain> Domains { get; set; }
    }
    public class Location
    {
        [Key] public string Name { get; set; }
        public Domain Domain { get; set; }
        public List<Edition> Editions { get; set; }
        public string Type { get; set; } //Like is it a town/city/cave/temple
        public Location? PartOf { get; set; }
        public List<Location> Contains { get; set; }
        public string Population { get; set; } //Maybe a number would be better?
        public string Description { get; set; }
        public List<NPC> NPCs { get; set; }
        public List<Creature> Creatures { get; set; }
        public List<Item> Items { get; set; }
        public List<Source> Sources { get; set; }
    }
    public class Item
    {
        [Key] public string Name { get; set; }
        public List<Domain> Domains { get; set; }
        public List<ItemTrait> Traits { get; set; }
        public List<Location> Locations { get; set; }
        public List<Source> Sources { get; set; }
    }
    public class ItemTrait
    {
        [Key] public string Name { get; set; }
        public List<Item> Items { get; set; }
    }
    public class Group
    {
        [Key] public string Name { get; set; }
        public Group? PartOf { get; set; }
        public List<Group> Contains { get; set; }
        public List<Source> Sources { get; set; }
    }
    public class NPC
    {
        [Key] public string Name { get; set; }
        public List<Domain> Domains { get; set; } //Some people travel
        public List<Edition> Editions { get; set; }
        public string Aliases { get; set; }
        public List<CreatureTrait> Traits { get; set; } //Like is he a gnome, darklord, vampire
        public List<Group> Groups { get; set; }
        public List<Location> Locations { get; set; } //Some people travel
        public List<Source> Sources { get; set; }
    }
    public class CreatureTrait
{
        [Key] public string Name { get; set; }
        public List<NPC>[] NPCs { get; set; }
    }
    public class Creature
    {
        [Key] public string Name { get; set; }
        public List<Domain> Domains { get; set; }
        public List<Edition> Editions { get; set; }
        public List<CreatureTrait> Traits { get; set; } //Like is he a gnome, darklord, vampire
        public List<Location> Locations { get; set; }
        public List<Source> Sources { get; set; }
    }
}
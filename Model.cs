using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ravenloft
{
    public class RavenloftContext : DbContext
    {
        public DbSet<Domain> Domains { get; set; }
        public RavenloftContext(DbContextOptions<RavenloftContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
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
        public List<Location> Locations { get; set; }
        public List<Source> Sources { get; set; }
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
        public List<Trait> Traits { get; set; } //Like is he a gnome, darklord, vampire
        public List<Group> Groups { get; set; }
        public List<Location> Locations { get; set; } //Some people travel
        public List<Source> Sources { get; set; }
    }
    public class Trait
{
        [Key] public string Name { get; set; }
        public List<NPC>[] NPCs { get; set; }
    }
    public class Creature
    {
        [Key] public string Name { get; set; }
        public List<Domain> Domains { get; set; }
        public List<Edition> Editions { get; set; }
        public List<Location> Locations { get; set; }
        public List<Source> Sources { get; set; }
    }
}
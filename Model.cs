using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class RavenloftContext// : DbContext
{
    public List<Source> Sources { get; set; } = new();
    public List<Source.Trait> SourceTraits { get; set; } = new();

    public List<Trait> Traits { get; set; } = new();

    public Dictionary<string, Domain> Domains { get; set; } = new();
    public Dictionary<string, Location> Locations { get; set; } = new();
    public Dictionary<string, Item> Items { get; set; } = new();
    public Dictionary<string, NPC> NPCs { get; set; } = new();
    public Dictionary<string, Group> Groups { get; set; } = new();
}

public abstract class UseName
{
    [Key] public string Key { get; set; } //Key
    public string ExtraInfo { get; set; } = string.Empty; //external links
}
public class Source : UseName
{
    public List<Domain> Domains { get; set; } = new();
    public List<Location> Locations { get; set; } = new();
    public List<NPC> NPCs { get; set; } = new();
    public List<Item> Items { get; set; } = new();
    public List<Group> Groups { get; set; } = new();
    public List<Trait> Traits { get; set; } = new();
    public string ReleaseDate { get; set; }
    //Levels, contributors, release date
    public class Trait : UseName
    {
        public string Type { get; set; }
        public List<Source> Sources { get; set; } = new();
    }
}

public class Trait : UseName, IHasDomains, IHasLocations, IHasItems, IHasNPCs, IHasGroups
{
    public string Type { get; set; }
    public Dictionary<string, Domain> Domains { get; set; } = new();
    public Dictionary<string, Location> Locations { get; set; } = new();
    public Dictionary<string, Item> Items { get; set; } = new();
    public Dictionary<string, NPC> NPCs { get; set; } = new();
    public Dictionary<string, Group> Groups { get; set; } = new();
}

public abstract class UseVariableName : UseName
{
    public string OriginalName { get; set; } //For searching purposes
    public Dictionary<string, string> Names { get; set; } = new();//Can be different in different sources
    public Dictionary<string, Trait> Traits { get; set; } = new();
    public Dictionary<string, string> PageNumbers { get; set; } = new();
}
public class Domain : UseVariableName, IHasLocations, IHasItems, IHasNPCs, IHasGroups
{
    public Dictionary<string,Location> Locations { get; set; } = new();
    public Dictionary<string,NPC> NPCs { get; set; } = new();
    public Dictionary<string,NPC> Darklords { get; set; } = new(); //Convenience
    public Dictionary<string,Item> Items { get; set; } = new();
    public Dictionary<string, Group> Groups { get; set; } = new();
    public Dictionary<string, Group> Clusters { get; set; } = new(); //Convenience
    //Recommended related media, recorded sessions
}
public class Location : UseVariableName, IHasDomains, IHasItems, IHasNPCs, IHasGroups
{
    public Dictionary<string,Domain> Domains { get; set; } = new();
    public Dictionary<string,NPC> NPCs { get; set; } = new();
    public Dictionary<string,Item> Items { get; set; } = new();
    public Dictionary<string, Group> Groups { get; set; } = new();
}
public class NPC : UseVariableName, IHasDomains, IHasLocations, IHasItems, IHasGroups
{
    public Dictionary<string, Domain> Domains { get; set; } = new();
    public Dictionary<string, Location> Locations { get; set; } = new();
    public Dictionary<string, Item> Items { get; set; } = new();
    public Dictionary<string, Group> Groups { get; set; } = new();
    public Dictionary<string, Trait> RelatedTraits { get; set; } = new();

    public Dictionary<string, Relationship> Relationships { get; set; } = new();
    public class Relationship
    {
        public NPC Primary { get; set; }
        public NPC Other { get; set; } = new();
        public string RelationshipType { get; set; }
    }
}
public class Item : UseVariableName, IHasDomains, IHasLocations, IHasNPCs, IHasGroups
{
    public Dictionary<string,Domain> Domains { get; set; } = new();
    public Dictionary<string,Location> Locations { get; set; } = new();
    public Dictionary<string,NPC> NPCs { get; set; } = new();
    public Dictionary<string, Group> Groups { get; set; } = new();
}
public class Group : UseVariableName, IHasDomains, IHasLocations, IHasItems, IHasNPCs
{
    public Dictionary<string,Domain> Domains { get; set; } = new();
    public Dictionary<string,NPC> NPCs { get; set; } = new();
    public Dictionary<string,Location> Locations { get; set; } = new();
    public Dictionary<string, Item> Items { get; set; } = new();
}
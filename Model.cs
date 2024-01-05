﻿using static Factory;

public static class Ravenloftdb
{
    public static readonly Dictionary<Edition, List<Source>> Editions = new();
    public static readonly Dictionary<Canon  , List<Source>> Canons   = new();
    public static readonly Dictionary<Media  , List<Source>> Medias   = new();

    public static readonly HashSet<Trait> CampaignSettings = new();

    public static readonly HashSet<Trait> Languages = new();
    public static readonly SortedDictionary<Domain, SortedSet<Trait>> LanguagesPerDomain = new();
    public static readonly SortedDictionary<Trait, SortedSet<Domain>> DomainsPerLanguage = new();

    public static readonly HashSet<Trait> Creatures = new();
    public static readonly SortedDictionary<Domain, SortedSet<Trait>> CreaturesPerDomain = new();
    public static readonly SortedDictionary<Trait, SortedSet<Domain>> DomainsPerCreature = new();

    public static readonly List<Source> Sources = new();

    public static readonly HashSet<Domain> Domains = new();

    public static readonly HashSet<Location> Locations = new();
    public static readonly SortedDictionary<Domain, SortedSet<Location>> LocationsPerDomain = new();
    public static readonly SortedDictionary<Domain, SortedSet<Location>> SettlementsPerDomain = new(); //Towns, Villages
    public static readonly HashSet<Location> Mistways = new(); //Location with only 2 domains

    public static readonly HashSet<NPC> Characters = new ();
    public static readonly SortedDictionary<Domain, SortedSet<NPC>> CharactersPerDomain = new();

    public static readonly HashSet<Item> Items = new();
    public static readonly SortedDictionary<Domain, SortedSet<Item>> ItemsPerDomain = new();

    public static readonly HashSet<Group> Groups = new();
    public static readonly SortedDictionary<Domain, SortedSet<Group>> GroupsPerDomain = new();
    public static readonly HashSet<Group> Clusters = new(); //Group with multiple domains
}
public class ToTrack<T>
{
    public readonly SortedSet<T> Total = new();
    public readonly Dictionary<Source, SortedSet<T>> PerSource = new();
    public void Add(Source source, IEnumerable<T> entities) => Add(source, entities.ToArray());
    public void Add(Source source, params T[] entities)
    {
        PerSource.TryAdd(source, new());
        Total.UnionWith(entities);
        PerSource[source].UnionWith(entities);
    }
}
public abstract class UseVariableName //Domain, Location, NPC, Item, Group
{
    public readonly HashSet<string> Names = new();

    public readonly HashSet<Source> Sources = new(); //Tracks all sources that has this entity

    public readonly ToTrack<Domain  > Domains    = new();
    public readonly ToTrack<Location> Locations  = new();
    public readonly ToTrack<Item    > Items      = new();
    public readonly ToTrack<NPC     > Characters = new();
    public readonly ToTrack<Group   > Groups     = new();
    public readonly ToTrack<Trait   > Languages  = new();
    public readonly ToTrack<Trait   > Creatures  = new();

    public string ExtraInfo = string.Empty;
    public Edition editions;
    public Trait? Setting; //You can kinda only really be from one campaign setting
}
public class TrackPage<T>
{
    public readonly T entity;
    public readonly Canon Canon;
    public readonly Source source;
    public readonly string PageNumbers;
    public string ExtraInfo = string.Empty;
    public TrackPage(T entity, Source source, string pageNumbers, Canon canon = Canon.c)
    { this.entity = entity; this.source = source; PageNumbers = pageNumbers; Canon = canon; }
}
public class Source
{
    public readonly SortedSet<TrackPage<Domain  >> Domains    = new();
    public readonly SortedSet<TrackPage<Location>> Locations  = new();
    public readonly SortedSet<TrackPage<NPC     >> Characters = new();
    public readonly SortedSet<TrackPage<Item    >> Items      = new();
    public readonly SortedSet<TrackPage<Group   >> Groups     = new();
    public readonly SortedSet<TrackPage<Group   >> Clusters   = new();
    public readonly SortedSet<TrackPage<Location>> Mistways   = new();

    public readonly SortedSet<Trait> Creatures = new();
    public readonly SortedSet<Trait> Languages = new();
    public readonly SortedSet<Trait> Settings = new();

    public string Name, ExtraInfo = string.Empty;
    public readonly string ReleaseDate;
    public readonly Edition editions;
    public readonly Media Media;
    public readonly Canon Canon;

    public Source (string Name, string ReleaseDate, Edition Edition, Media Media, Canon Canon = Canon.c)
    { 
        this.Name = Name; this.ReleaseDate = ReleaseDate;
        editions = Edition; this.Media = Media; this.Canon = Canon;
    }
    //Levels, contributors, release date
}
public class Trait : UseVariableName //Don't track page numbers?
{
    public Trait(params string[] names) => Names.UnionWith(names);
}
public class Location : UseVariableName, IHasAppearances<Location>
{
    public Dictionary<Source, TrackPage<Location>> Appearances { get; init; } = new();
    public Location(params string[] names) => Names.UnionWith(names);
}
public class Item : UseVariableName, IHasAppearances<Item>, IHasAlignment
{
    public Dictionary<Source, TrackPage<Item>> Appearances { get; init; } = new();

    public Dictionary<Source, Alignment> AlignmentPerSource { get; init; } = new();
    public Item(params string[] names) => Names.UnionWith(names);
}
public class Group : UseVariableName, IHasAppearances<Group>
{
    public Dictionary<Source, TrackPage<Group>> Appearances { get; init; } = new();
    public Group(params string[] names) => Names.UnionWith(names);
}
public class Domain : UseVariableName, IHasAppearances<Domain>
{
    public          Dictionary<Source, TrackPage<Domain  >> Appearances { get; init; } = new();
    public readonly ToTrack<Darklord> Darklords = new();
    public readonly ToTrack<Group   > Clusters  = new();
    public readonly ToTrack<Location> Mistways  = new();
    public readonly string MistTalismans = string.Empty;
    public Domain(params string[] names) => Names.UnionWith(names);
    public class Darklord : NPC
    {
        public Location? DarklordLair; //I uhh, haven't heard of any darklord having more than one lair
        public string Curse = string.Empty, CloseBorder = string.Empty;
    }
}
public class NPC : UseVariableName, IHasAppearances<NPC>, IHasAlignment
{
    public          Dictionary<Source, TrackPage<NPC     >> Appearances { get; init; } = new();

    public readonly ToTrack<Trait> RelatedCreatures = new();

    public readonly Dictionary<Source, bool              > Deceased      = new();
    public readonly Dictionary<Source, List<Relationship>> Relationships = new();

    public Dictionary<Source, Alignment> AlignmentPerSource { get; init; } = new();

    public NPC(params string[] names) => Names.UnionWith(names);
    public class Relationship
    {
        public readonly NPC Primary, Other;
        public readonly string RelationshipType;
        public Relationship(NPC Primary, string RelationshipType, NPC Other)
        {
            this.Primary = Primary;
            this.RelationshipType = RelationshipType;
            this.Other = Other;
        }
    }
}

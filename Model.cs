using static Factory;

public static class Ravenloftdb
{
    public static readonly Dictionary<Edition, List<Source>> Editions = new();
    public static readonly Dictionary<Canon  , List<Source>> Canons   = new();
    public static readonly Dictionary<Media  , List<Source>> Medias   = new();

    public static readonly Dictionary<Traits.CampaignSetting, Trait> CampaignSettings = new();

    public static readonly SortedDictionary<DomainEnum, SortedSet<Trait>> LanguagesPerDomain = new();
    public static readonly SortedDictionary<Trait, SortedSet<DomainEnum>> DomainsPerLanguage = new();
    public static readonly SortedDictionary<Trait, SortedSet<NPC>> CharactersPerLanguage     = new();

    public static readonly SortedDictionary<DomainEnum, SortedSet<Trait>> CreaturesPerDomain = new();
    public static readonly SortedDictionary<Trait, SortedSet<DomainEnum>> DomainsPerCreature = new();

    public static readonly List<Source> Sources = new();

    public static readonly SortedDictionary<DomainEnum, Domain> Domains = new();

    public static readonly Dictionary<string, Location> Locations = new();
    public static readonly SortedDictionary<DomainEnum, SortedSet<Location>> LocationsPerDomain = new();
    public static readonly SortedDictionary<DomainEnum, SortedSet<Location>> SettlementsPerDomain = new(); //Towns, Villages

    public static readonly Dictionary<string, NPC> Characters = new ();
    public static readonly SortedDictionary<DomainEnum, SortedSet<NPC>> CharactersPerDomain = new();
    public static readonly SortedDictionary<NPC       , SortedSet<NPC>> CharactersPerGroup = new();
    public static readonly SortedDictionary<Trait     , SortedSet<NPC>> CharactersPerCreature = new();

    public static readonly Dictionary<string, Item> Items = new();
    public static readonly SortedDictionary<DomainEnum, SortedSet<Item>> ItemsPerDomain = new();
    public static readonly SortedDictionary<Item, SortedSet<Item>> ItemsPerGroup = new();
    public static readonly SortedDictionary<Trait, SortedSet<Item>> ItemsPerCreature= new();
    public static readonly SortedDictionary<DomainEnum, SortedSet<Item>> MistTalismansPerDomain = new();

    public static readonly Dictionary<string, Group> Groups = new();
    public static readonly Dictionary<MistwayEnum, Group> Mistways = new(); //Group with only 2 domains
    public static readonly Dictionary<ClusterEnum, Group> Clusters = new(); //Group with multiple domains
    public static readonly SortedDictionary<DomainEnum, SortedSet<Group>> GroupsPerDomain = new();
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

    public readonly Trait? Settings; //You can kinda only really be from one campaign setting

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
}
public class TrackPage<T>
{
    public readonly T entity;
    public readonly Source source;
    public readonly string PageNumbers;
    public string ExtraInfo = string.Empty;
    public TrackPage(T entity, Source source, string pageNumbers)
    { this.entity = entity; this.source = source; PageNumbers = pageNumbers; }
}
public class Source
{
    public readonly SortedSet<TrackPage<Domain  >> Domains    = new();
    public readonly SortedSet<TrackPage<Location>> Locations  = new();
    public readonly SortedSet<TrackPage<NPC     >> Characters = new();
    public readonly SortedSet<TrackPage<Item    >> Items      = new();
    public readonly SortedSet<TrackPage<Group   >> Groups     = new();
    public readonly SortedSet<TrackPage<Group   >> Clusters   = new();
    public readonly SortedSet<TrackPage<Group   >> Mistways   = new();

    public readonly SortedSet<Trait> Creatures = new();
    public readonly SortedSet<Trait> Languages = new();
    public readonly SortedSet<Trait> Settings = new();

    public string Name, ExtraInfo = string.Empty;
    public readonly string ReleaseDate;
    public readonly Edition editions;
    public readonly Media Media;
    public readonly Canon? Canon;

    public Source (string Name, string ReleaseDate, Edition Edition, Media Media, Canon? Canon = null)
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
}
public class Item : UseVariableName, IHasAppearances<Item>
{
    public Dictionary<Source, TrackPage<Item>> Appearances { get; init; } = new();
}
public class Group : UseVariableName, IHasAppearances<Group>
{
    public Dictionary<Source, TrackPage<Group>> Appearances { get; init; } = new();
}
public class Domain : UseVariableName, IHasAppearances<Domain>
{
    public          Dictionary<Source, TrackPage<Domain  >> Appearances { get; init; } = new();
    public readonly ToTrack<Darklord> Darklords = new();
    public readonly ToTrack<Group   > Clusters     = new();
    public readonly ToTrack<Group   > Mistways     = new();
    public readonly ToTrack<Item    > MistTalismans = new();
    public Domain (string[] names) => Names.UnionWith(names);
    public class Darklord : NPC
    {
        public Location? DarklordLair; //I uhh, haven't heard of any darklord having more than one lair
        public string Curse = string.Empty, CloseBorder = string.Empty;
    }
}
public class NPC : UseVariableName, IHasAppearances<NPC>
{
    public          Dictionary<Source, TrackPage<NPC     >> Appearances { get; init; } = new();

    public readonly ToTrack<Trait> RelatedCreatures = new();

    public readonly Dictionary<Source, bool              > Deceased      = new();
    public readonly Dictionary<Source, List<Relationship>> Relationships = new();
    public readonly HashSet<Trait> Alignments = new ();

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

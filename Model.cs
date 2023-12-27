using static Factory;

public static class Ravenloftdb
{
    public static readonly Dictionary<Edition, List<Source>> Editions = new();
    public static readonly Dictionary<Canon  , List<Source>> Canons   = new();
    public static readonly Dictionary<Media  , List<Source>> Medias   = new();

    public static readonly SortedDictionary<Trait, SortedSet<string>> NPCsPerCampaignSetting   = new();
    public static readonly SortedDictionary<Trait, SortedSet<string>> ItemsPerCampaignSetting  = new();
    public static readonly SortedDictionary<Trait, SortedSet<string>> GroupsPerCampaignSetting = new();

    public static readonly SortedDictionary<Trait, SortedSet<string>> DomainsPerLanguage = new();
    public static readonly SortedDictionary<Trait, SortedSet<string>> NPCsPerLanguage    = new();

    public static readonly SortedDictionary<Trait, SortedSet<string>> DomainsPerCreature = new();

    public static readonly List<Source> Sources = new();

    public static readonly SortedDictionary<DomainEnum, Domain> Domains = new();

    public static readonly HashSet<Location> Locations = new();
    public static readonly SortedDictionary<DomainEnum, SortedSet<Location>> LocationsPerDomain = new();
    public static readonly SortedDictionary<DomainEnum, SortedSet<Location>> SettlementsPerDomain = new(); //Towns, Villages

    public static readonly HashSet<NPC> Characters = new ();
    public static readonly SortedDictionary<DomainEnum, SortedSet<NPC>> CharactersPerDomain = new();
    public static readonly SortedDictionary<Entity    , SortedSet<NPC>> CharactersPerGroup = new();
    public static readonly SortedDictionary<Trait     , SortedSet<NPC>> CharactersPerCreature = new();

    public static readonly HashSet<Item> Items = new();
    public static readonly SortedDictionary<DomainEnum, SortedSet<Item>> ItemsPerDomain = new();
    public static readonly SortedDictionary<Entity, SortedSet<Item>> ItemsPerGroup = new();
    public static readonly SortedDictionary<Trait, SortedSet<Item>> ItemsPerCreature= new();

    public static HashSet<Group> Groups => GroupsPerDomain.SelectMany(kv => kv.Value).ToHashSet();
    public static readonly SortedDictionary<DomainEnum, SortedSet<Group>> GroupsPerDomain = new();

    public static readonly Dictionary<MistwayEnum, Mistway> Mistways = new();
    public static readonly Dictionary<ClusterEnum, Cluster> Clusters = new();
}

public abstract class UseName
{
    public string Name, ExtraInfo = string.Empty;
    public Edition editions;
}
public abstract class UseVariableName //Domain, Location, NPC, Item, Group
{
    public readonly HashSet<string> Names = new();

    public readonly HashSet<Trait> Languages = new();
    public readonly HashSet<Trait> Creatures = new();
    public readonly HashSet<Trait> Settings  = new();

    public readonly HashSet<Source> Sources = new(); //Tracks all sources that has this entity
    public readonly Dictionary<Source, SortedSet<Domain  >> Domains    = new();
    public readonly Dictionary<Source, SortedSet<Location>> Locations  = new();
    public readonly Dictionary<Source, SortedSet<Item    >> Items      = new();
    public readonly Dictionary<Source, SortedSet<NPC     >> Characters = new();
    public readonly Dictionary<Source, SortedSet<Group   >> Groups     = new();

    public string ExtraInfo = string.Empty;
    public Edition editions;
}
public class InSource<T>
{
    public readonly T entity;
    public readonly Source source;
    public readonly string PageNumbers;
    public string ExtraInfo = string.Empty;
    public InSource(T entity, Source source, string pageNumbers)
    {
        this.entity = entity;
        this.source = source;
        PageNumbers = pageNumbers;
    }
}
public class Trait
{
    public readonly string Name, ExtraInfo;
    public readonly SortedSet<Domain> Domains     = new();
    public readonly SortedSet<Entity> Locations   = new();
    public readonly SortedSet<NPC   > Characters  = new();
    public readonly SortedSet<Entity> Items       = new();
    public readonly SortedSet<Entity> Groups      = new();
    public Trait(string Name, string ExtraInfo) { this.Name = Name; this.ExtraInfo = ExtraInfo; }
}

public class Source : UseName
{
    public readonly SortedSet<InSource<Domain  >> Domains    = new();
    public readonly SortedSet<InSource<Location>> Locations  = new();
    public readonly SortedSet<InSource<NPC     >> Characters = new();
    public readonly SortedSet<InSource<Item    >> Items      = new();
    public readonly SortedSet<InSource<Group   >> Groups     = new();
    public readonly SortedSet<InSource<Cluster >> Clusters   = new();
    public readonly SortedSet<InSource<Mistway >> Mistways   = new();

    public readonly SortedSet<Trait> Creatures = new();
    public readonly SortedSet<Trait> Languages = new();
    public readonly SortedSet<Trait> Settings = new();

    public readonly string ReleaseDate;
    public readonly Media Media;
    public readonly Canon? Canon;

    public Source (string Name, string ReleaseDate, Edition Edition, Media Media, Canon? Canon = null)
    { 
        this.Name = Name;
        this.ReleaseDate = ReleaseDate;
        editions = Edition;
        this.Media = Media;
        this.Canon = Canon;
    }
    //Levels, contributors, release date
}
public abstract class Entity : UseVariableName, IHasAppearances<Entity> //Location, Item, Group, Cluster, Mistway
{
    public Dictionary<Source, InSource<Entity>> Appearances { get; init; } = new();
}
public class Location : Entity { }
public class Item : Entity { }
public class Group : Entity { }
public class Cluster : Entity { }
public class Mistway : Entity { }
public class Domain : UseVariableName, IHasAppearances<Domain>
{
    public          Dictionary<Source, InSource <Domain  >> Appearances { get; init; } = new();
    public readonly Dictionary<Source, SortedSet<Darklord>> Darklords = new(); //Convenience
    public readonly Dictionary<Source, SortedSet<Cluster >> Clusters  = new(); //Convenience
    public readonly Dictionary<Source, SortedSet<Mistway >> Mistways  = new(); //Convenience
    public class Darklord : NPC
    {
        public Entity? DarklordLair;
        public string Curse = string.Empty, CloseBorder = string.Empty;
    }
}
public class NPC : UseVariableName, IHasAppearances<NPC>
{
    public          Dictionary<Source, InSource<NPC     >> Appearances { get; init; } = new();
    public readonly Dictionary<Source, HashSet<Trait    >> RelatedTraits = new();
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

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

    public static readonly Dictionary<string, Location> Locations = new();
    public static readonly SortedDictionary<DomainEnum, SortedSet<Location>> LocationsPerDomain = new();
    public static readonly SortedDictionary<DomainEnum, SortedSet<Location>> SettlementsPerDomain = new(); //Towns, Villages

    public static readonly Dictionary<string, NPC> Characters = new ();
    public static readonly SortedDictionary<DomainEnum, SortedSet<NPC>> CharactersPerDomain = new();
    public static readonly SortedDictionary<NPC    , SortedSet<NPC>> CharactersPerGroup = new();
    public static readonly SortedDictionary<Trait     , SortedSet<NPC>> CharactersPerCreature = new();

    public static readonly Dictionary<string, Item> Items = new();
    public static readonly SortedDictionary<DomainEnum, SortedSet<Item>> ItemsPerDomain = new();
    public static readonly SortedDictionary<Item, SortedSet<Item>> ItemsPerGroup = new();
    public static readonly SortedDictionary<Trait, SortedSet<Item>> ItemsPerCreature= new();

    public static readonly Dictionary<string, Group> Groups = new();
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

    public readonly SortedSet<Domain  > Domains    = new();
    public readonly SortedSet<Location> Locations  = new();
    public readonly SortedSet<Item    > Items      = new();
    public readonly SortedSet<NPC     > Characters = new();
    public readonly SortedSet<Group   > Groups     = new();

    public readonly HashSet<Source> Sources = new(); //Tracks all sources that has this entity
    public readonly Dictionary<Source, SortedSet<Domain  >> DomainsPerSource    = new();
    public readonly Dictionary<Source, SortedSet<Location>> LocationsPerSource  = new();
    public readonly Dictionary<Source, SortedSet<Item    >> ItemsPerSource      = new();
    public readonly Dictionary<Source, SortedSet<NPC     >> CharactersPerSource = new();
    public readonly Dictionary<Source, SortedSet<Group   >> GroupsPerSource     = new();

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
    public readonly SortedSet<Domain  > Domains     = new();
    public readonly SortedSet<Location> Locations   = new();
    public readonly SortedSet<NPC     > Characters  = new();
    public readonly SortedSet<Item    > Items       = new();
    public readonly SortedSet<Group   > Groups      = new();
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
public class Location : UseVariableName, IHasAppearances<Location>
{
    public Dictionary<Source, InSource<Location>> Appearances { get; init; } = new();
}
public class Item : UseVariableName, IHasAppearances<Item>
{
    public Dictionary<Source, InSource<Item>> Appearances { get; init; } = new();
}
public class Group : UseVariableName, IHasAppearances<Group>
{
    public Dictionary<Source, InSource<Group>> Appearances { get; init; } = new();
}
public class Cluster : UseVariableName, IHasAppearances<Cluster>
{
    public Dictionary<Source, InSource<Cluster>> Appearances { get; init; } = new();
}
public class Mistway : UseVariableName, IHasAppearances<Mistway>
{
    public Dictionary<Source, InSource<Mistway>> Appearances { get; init; } = new();
}
public class Domain : UseVariableName, IHasAppearances<Domain>
{
    public          Dictionary<Source, InSource <Domain  >> Appearances { get; init; } = new();
    public readonly SortedSet<Darklord> Darklords = new();
    public readonly SortedSet<Cluster > Clusters  = new();
    public readonly SortedSet<Mistway > Mistways  = new();
    public readonly Dictionary<Source, SortedSet<Darklord>> DarklordsPerSource = new();
    public readonly Dictionary<Source, SortedSet<Cluster >> ClustersPerSource  = new();
    public readonly Dictionary<Source, SortedSet<Mistway >> MistwaysPerSource  = new();
    public class Darklord : NPC
    {
        public Location? DarklordLair; //I uhh, haven't heard of any darklord having more than one lair
        public string Curse = string.Empty, CloseBorder = string.Empty;
    }
}
public class NPC : UseVariableName, IHasAppearances<NPC>
{
    public          Dictionary<Source, InSource<NPC     >> Appearances { get; init; } = new();

    public readonly HashSet<Trait> RelatedTraits = new();
    public readonly Dictionary<Source, HashSet<Trait    >> RelatedTraitsPerSource = new();

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

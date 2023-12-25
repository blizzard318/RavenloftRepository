public static class Ravenloftdb
{
    public static Dictionary<string, List<Source>> Editions = new();
    public static Dictionary<string, List<Source>> Canons   = new();
    public static Dictionary<string, List<Source>> Medias   = new();

    public static List<Trait> CampaignSettings = new();
    public static List<Trait> Languages        = new();
    public static List<Trait> Creatures        = new();
    public static List<Trait> Alignments       = new();

    public static List<Source> Sources = new();

    public static SortedDictionary<string, Domain         > Domains   = new();
    public static SortedDictionary<string, Entity         > Locations = new();
    public static SortedDictionary<string, Entity         > Mistways = new();
    public static SortedDictionary<string, Entity         > Items     = new();
    public static SortedDictionary<string, NPC            > NPCs      = new();
    public static SortedDictionary<string, Domain.Darklord> Darklords = new();
    public static SortedDictionary<string, Entity         > Groups    = new();
}

public abstract class UseName
{
    public string OriginalName, ExtraInfo = string.Empty; //external links
    public override bool Equals(object obj)
    {
        if (obj == null || obj is not UseName) return false;
        return OriginalName == ((UseName)obj).OriginalName;
    }
    public override int GetHashCode() => OriginalName.GetHashCode();
}
public class Source : UseName
{
    public SortedSet<InSource<Domain>> Domains   = new();
    public SortedSet<InSource<Entity>> Locations = new();
    public SortedSet<InSource<NPC   >> NPCs      = new();
    public SortedSet<InSource<Entity>> Items     = new();
    public SortedSet<InSource<Entity>> Groups    = new();

    public readonly string ReleaseDate, Edition, Media;
    public readonly string? Canon;

    public Source (string originalName, string ReleaseDate, string Edition, string Media, string? Canon = null)
    { 
        OriginalName = originalName;
        this.ReleaseDate = ReleaseDate;
        this.Edition = Edition;
        this.Media = Media;
        if (Canon != null) this.Canon = Canon;
    }
    //Levels, contributors, release date
}
public class InSource<T>
{
    public readonly T entity;
    public readonly Source source;
    public readonly string PageNumbers;
    public HashSet<Trait> Traits = new();
    public string ExtraInfo = string.Empty;
    public InSource(T entity, Source source, string pageNumbers)
    {
        this.entity = entity;
        this.source = source;
        PageNumbers = pageNumbers;
    }
}
public class Trait : UseName
{
    public SortedSet<Domain> Domains   = new();
    public SortedSet<Entity> Locations = new();
    public SortedSet<NPC   > NPCs      = new();
    public SortedSet<Entity> Items     = new();
    public SortedSet<Entity> Groups    = new();
}
public abstract class UseVariableName : UseName //Domain, Location, NPC, Item, Group
{
    public HashSet<string> Names = new();
    public HashSet<Trait> Traits = new();
    public Dictionary<Source, SortedSet<Domain>> Domains    = new();
    public Dictionary<Source, SortedSet<Entity>> Locations  = new();
    public Dictionary<Source, SortedSet<Entity>> Items      = new();
    public Dictionary<Source, SortedSet<NPC   >> NPCs       = new();
    public Dictionary<Source, SortedSet<Entity>> Groups     = new();
}
public class Entity : UseVariableName, IHasAppearances<Entity> //Location, Item, Group
{
    public Dictionary<Source, InSource<Entity>> Appearances { get; set; } = new();
}
public class Domain : UseVariableName, IHasAppearances<Domain>
{
    public Dictionary<Source, InSource <Domain  >> Appearances { get; set; } = new();
    public Dictionary<Source, SortedSet<Darklord>> Darklords = new(); //Convenience
    public Dictionary<Source, SortedSet<Cluster >> Clusters  = new(); //Convenience
                                                               //Recommended related media, recorded sessions
    public class Cluster : UseName
    {
        public SortedSet<Domain> Domains = new();
    }

    public class Darklord : NPC
    {
        public Entity? DarklordLair;
        public string Curse = string.Empty, CloseBorder = string.Empty;
    }
}
public class NPC : UseVariableName, IHasAppearances<NPC>
{
    public Dictionary<Source, InSource<NPC     >> Appearances { get; set; } = new();
    public Dictionary<Source, HashSet<Trait    >> RelatedTraits = new();
    public Dictionary<Source, bool              > Deceased      = new();
    public Dictionary<Source, List<Relationship>> Relationships = new();
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

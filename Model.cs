public class RavenloftContext// : DbContext
{
    public List<Source.Trait> Editions = new();
    public List<Source.Trait> Canons   = new();
    public List<Source.Trait> Medias   = new();

    public List<Trait> CampaignSettings = new();
    public List<Trait> Languages        = new();
    public List<Trait> Creatures        = new();
    public List<Trait> Alignments       = new();

    public List<Source> Sources = new();

    public SortedDictionary<string, Domain         > Domains   = new();
    public SortedDictionary<string, UseVariableName> Locations = new();
    public SortedDictionary<string, UseVariableName> Items     = new();
    public SortedDictionary<string, NPC            > NPCs      = new();
    public SortedDictionary<string, UseVariableName> Groups    = new();
}

public abstract class UseName
{
    public readonly string OriginalName; //For searching purposes
    public string ExtraInfo = string.Empty; //external links
    public UseName(string originalName) => OriginalName = originalName;
    public override bool Equals(object obj)
    {
        if (obj == null || obj is not UseName) return false;
        return OriginalName == ((UseName)obj).OriginalName;
    }
    public override int GetHashCode() => OriginalName.GetHashCode();
}
public class Source : UseName
{
    public SortedSet<InSource<Domain         >> Domains   = new();
    public SortedSet<InSource<UseVariableName>> Locations = new();
    public SortedSet<InSource<NPC            >> NPCs      = new();
    public SortedSet<InSource<UseVariableName>> Items     = new();
    public SortedSet<InSource<UseVariableName>> Groups    = new();

    public readonly Trait Edition, Media;
    public readonly Trait? Canon;
    public readonly string ReleaseDate = string.Empty;
    
    public Source (string originalName, string ReleaseDate, Trait Edition, Trait Media, Trait? Canon = null) : base(originalName)
    {  this.Edition = Edition; this.ReleaseDate = ReleaseDate; this.Media = Media; this.Canon = Canon; }

    //Levels, contributors, release date
    public class Trait : UseName
    {
        public List<Source> Sources = new();
        public Trait (string originalName) : base (originalName) { }
    }
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
    public SortedSet<Domain         > Domains   = new();
    public SortedSet<UseVariableName> Locations = new();
    public SortedSet<NPC            > NPCs      = new();
    public SortedSet<UseVariableName> Items     = new();
    public SortedSet<UseVariableName> Groups    = new();
    public Trait(string originalName) : base(originalName) { }
}
public class UseVariableName : UseName//Domain, Location, NPC, Item, Group
{
    public HashSet<string> Names = new();
    public HashSet<Trait> Traits = new();
    public Dictionary<Source, SortedSet<Domain         >> Domains    = new();
    public Dictionary<Source, SortedSet<UseVariableName>> Locations  = new();
    public Dictionary<Source, SortedSet<UseVariableName>> Items      = new();
    public Dictionary<Source, SortedSet<NPC            >> NPCs       = new();
    public Dictionary<Source, SortedSet<UseVariableName>> Groups     = new();
    public UseVariableName(string originalName) : base(originalName) { }
}
public class Entity : UseVariableName, IHasAppearances<Entity>
{
    public Dictionary<Source, InSource<Entity>> Appearances { get; set; } = new();
    public Entity(string originalName) : base(originalName) { }
}
public class Domain : UseVariableName, IHasAppearances<Domain>
{
    public Dictionary<Source, InSource<Domain  >> Appearances { get; set; } = new();
    public     Dictionary<Source, SortedSet<NPC    >> Darklords   = new(); //Convenience
    public     Dictionary<Source, SortedSet<Cluster>> Clusters    = new(); //Convenience
                                                               //Recommended related media, recorded sessions
    public Domain(string originalName) : base(originalName) { }
    public class Cluster : UseName
    {
        public SortedSet<Domain> Domains = new();
        public Cluster(string originalName) : base(originalName) { }
    }
}
public class NPC : UseVariableName, IHasAppearances<NPC>
{
    public Dictionary<Source, InSource<NPC     >> Appearances { get; set; } = new();
    public     Dictionary<Source, HashSet<Trait    >> RelatedTraits = new();
    public     Dictionary<Source, List<Relationship>> Relationships = new();
    public NPC(string originalName) : base(originalName) { }
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

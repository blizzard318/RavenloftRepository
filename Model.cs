public class RavenloftContext// : DbContext
{
    public List<Source> Sources = new();
    public List<Source.Trait> Editions = new();
    public List<Source.Trait> Canons = new();
    public List<Source.Trait> Medias = new();

    public List<Trait> CampaignSettings = new();
    public List<Trait> Alignments = new();
    public List<Trait> Languages = new();
    public List<Trait> Creatures = new();

    public Dictionary<string, Domain> Domains = new();
    public Dictionary<string, UseVariableName> Locations = new();
    public Dictionary<string, UseVariableName> Items = new();
    public Dictionary<string, NPC> NPCs = new();
    public Dictionary<string, UseVariableName> Groups = new();
}

public abstract class UseName
{
    public string OriginalName { get; set; } //For searching purposes
    public string ExtraInfo = string.Empty; //external links
}
public class Source : UseName
{
    public List<InSource<Domain         >> Domains   = new();
    public List<InSource<UseVariableName>> Locations = new();
    public List<InSource<NPC            >> NPCs      = new();
    public List<InSource<UseVariableName>> Items     = new();
    public List<InSource<UseVariableName>> Groups    = new();

    public Trait Edition, Canon, Media;
    public string ReleaseDate;

    //Levels, contributors, release date
    public class Trait : UseName
    {
        public string Type;
        public List<Source> Sources = new();
    }
}
public class InSource<T>
{
    public T entity;
    public Source source;
    public HashSet<string> Names;
    public HashSet<Trait> Traits;
    public string PageNumbers, ExtraInfo;
}
public class Trait : UseName
{
    public List<Domain> Domains = new();
    public List<UseVariableName> Locations = new();
    public List<NPC> NPCs = new();
    public List<UseVariableName> Items = new();
    public List<UseVariableName> Groups = new();
}
public abstract class UseVariableName : UseName
{
    public Dictionary<Source, InSource<UseVariableName>> Appearances = new();

    public Dictionary<string, Domain> Domains = new();
    public Dictionary<string, UseVariableName> Locations = new();
    public Dictionary<string, UseVariableName> Items = new();
    public Dictionary<string, NPC> NPCs = new();
    public Dictionary<string, UseVariableName> Groups = new();
}
public class Domain : UseVariableName
{
    public Dictionary<string, NPC> Darklords = new(); //Convenience
    public Dictionary<string, UseVariableName> Clusters = new(); //Convenience
    //Recommended related media, recorded sessions
}
public class NPC : UseVariableName
{
    public Dictionary<string, Trait> RelatedTraits = new();
    public Dictionary<string, Relationship> Relationships = new();
    public class Relationship
    {
        public NPC Primary { get; set; }
        public NPC Other { get; set; } = new();
        public string RelationshipType { get; set; }
    }
}
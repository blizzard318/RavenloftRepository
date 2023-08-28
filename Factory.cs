using System;
using static Relationship;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Factory : IDisposable
{
    public readonly static RavenloftContext db = new RavenloftContext();

    private readonly Source Source;
    private readonly List<Domain> domains = new(); //For trait distribution

    /*public static NPC GetNPC (string name) => NPCAppearances.Single(a => a.Source ==  Source && a.Entity.Search == name).Entity;
    public static Location GetLocation (string name) => LocationAppearances.Single(a => a.Source ==  Source && a.Entity.Search == name).Entity;
    public static Domain GetDomain(string name) => DomainAppearances.Single(a => a.Source == Source && a.Entity.Search == name).Entity;
    public static Item GetItem(string name) => ItemAppearances.Single(a => a.Source == Source && a.Entity.Search == name).Entity;*/

    public void Dispose ()
    {
        foreach (var domain in domains)
        {
            foreach (var location in domain.Locations)
            {
                foreach (var npc in location.NPCs) domain.NPCs.Add(npc);
                foreach (var trait in location.Traits) domain.Traits.Add(trait);
            }
            foreach (var item in domain.Items)
            {
                foreach (var trait in item.Traits) domain.Traits.Add(trait);
            }
            foreach (var npc in domain.NPCs)
            {
                foreach (var trait in npc.Traits) domain.Traits.Add(trait);
            }
        }
    }

    public static Factory? CreateSource(string name, string releaseDate, string extraInfo, params Source.Trait[] traits)
        => (db.Sources.Find(name) != null) ? null : new Factory(name, releaseDate, extraInfo, traits);
    private Factory(string name, string releaseDate, string extraInfo, params Source.Trait[] traits)
    {
        Source = db.Sources.Add(new Source()
        {
            Key = name,
            Traits = new(traits),
            ReleaseDate = releaseDate,
            ExtraInfo = extraInfo
        }).Entity;
        foreach (var trait in traits) trait.Sources.Add(Source);
    }

    public Domain CreateDomain(string name, string? pageNumbers = null) => CreateDomain(name, name, pageNumbers);
    public Domain CreateDomain(string name, string originalName, string? pageNumbers = null)
    {
        var retval = db.Domains.Add(new Domain()
        {
            Key = Source.Key + "/" + name,
            Name = name,
            OriginalName = originalName
        }).Entity;

        domains.Add(retval); //Important for trait distribution

        db.domainAppearances.Add(new DomainAppearance()
        { 
            Source = Source,
            Entity = retval,
            PageNumbers = pageNumbers == null ? "Throughout" : string.Join(',', pageNumbers)
        });
        return retval;
    }

    public Location CreateLocation(string name, string? pageNumbers = null) => CreateLocation(name, name, pageNumbers);
    public Location CreateLocation(string name, string originalName, string? pageNumbers = null)
    {
        var retval = db.Locations.Add(new Location()
        {
            Key = Source.Key + "/" + name,
            Name = name,
            OriginalName = originalName
        }).Entity;

        db.locationAppearances.Add(new LocationAppearance()
        {
            Source = Source,
            Entity = retval,
            PageNumbers = pageNumbers == null ? "Throughout" : string.Join(',', pageNumbers)
        });
        return retval;
    }

    public NPC CreateNPC(string name, string? pageNumbers = null) => CreateNPC(name, name, pageNumbers);
    public NPC CreateNPC(string name, string originalName, string? pageNumbers = null)
    {
        var retval = db.NPCs.Add(new NPC()
        {
            Key = Source.Key + "/" + name,
            Name = name,
            OriginalName = originalName
        }).Entity;

        db.npcAppearances.Add(new NPCAppearance()
        {
            Source = Source,
            Entity = retval,
            PageNumbers = pageNumbers == null ? "Throughout" : string.Join(',', pageNumbers)
        });
        return retval;
    }

    public Item CreateItem(string name, string? pageNumbers = null) => CreateItem(name, name, pageNumbers);
    public Item CreateItem(string name, string originalName, string? pageNumbers = null)
    {
        var retval = db.Items.Add(new Item()
        {
            Key = Source.Key + "/" + name,
            Name = name,
            OriginalName = originalName
        }).Entity;

        db.itemAppearances.Add(new ItemAppearance()
        {
            Source = Source,
            Entity = retval,
            PageNumbers = pageNumbers == null ? "Throughout" : string.Join(',', pageNumbers)
        });
        return retval;
    }

    public void CreateRelationship(NPC primary, RelationshipType type, NPC other)
    {
        var relationship = new Relationship()
        {
            Primary = primary,
            Type = type,
            Other = other,
        };
        primary.Relationships.Add(relationship);
        other.IgnoreThis.Add(relationship);
    }

    public static Source.Trait CreateSourceTrait(string name, string type) =>
        db.SourceTraits.Find(name) ??
        db.SourceTraits.Add(new Source.Trait() { Key = name, Type = type }).Entity;

    public static Trait CreateTrait(string name, params string[] types) =>
        db.Traits.Find(name) ??
        db.Traits.Add(new Trait() { Key = name, Type = string.Join(',', types) }).Entity;
}

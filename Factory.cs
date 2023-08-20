using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using static Relationship;

internal static class ctx
{
    private static RavenloftContext db;
    private static Source Source;

    public static IIncludableQueryable<TraitAppearance, Trait> TraitAppearances;
    public static IIncludableQueryable<NPCAppearance, NPC> NPCAppearances;
    public static IIncludableQueryable<LocationAppearance, Location> LocationAppearances;
    public static IIncludableQueryable<DomainAppearance, Domain> DomainAppearances;
    public static IIncludableQueryable<ItemAppearance, Item> ItemAppearances;

    public static NPC GetNPC (string name) => NPCAppearances.Single(a => a.Source ==  Source && a.Entity.Search == name).Entity;
    public static Location GetLocation (string name) => LocationAppearances.Single(a => a.Source ==  Source && a.Entity.Search == name).Entity;
    public static Domain GetDomain(string name) => DomainAppearances.Single(a => a.Source == Source && a.Entity.Search == name).Entity;
    public static Item GetItem(string name) => ItemAppearances.Single(a => a.Source == Source && a.Entity.Search == name).Entity;

    static ctx()
    {
        db = new RavenloftContext();
        TraitAppearances    = db.traitAppearances   .Include(a => a.Entity);
        NPCAppearances      = db.npcAppearances     .Include(a => a.Entity);
        LocationAppearances = db.locationAppearances.Include(a => a.Entity);
        DomainAppearances   = db.domainAppearances  .Include(a => a.Entity);
        ItemAppearances     = db.itemAppearances    .Include(a => a.Entity);
    }

    public static bool CreateSource(string name, DateTime releaseDate, string extraInfo, params SourceTrait[] traits)
    {
        Source = db.Sources.Find(name);
        if (Source != null) return false; //If it exists, say failed to create

        Source = new Source();
        Source.Name = name;
        Source.Traits = new(traits);
        Source.ReleaseDate = releaseDate;
        Source.ExtraInfo = extraInfo;
        foreach (var trait in traits) trait.Sources.Add(Source);
        db.Add(Source);
        return true;
    }
    public static void AddTraitApperance(Trait trait, params int[] pageNumbers) =>
        db.Add(new TraitAppearance()
        {
            Source = Source,
            Entity = trait,
            PageNumbers = pageNumbers.Length == 0 ? "Throughout" : string.Join(',', pageNumbers)
        });

    public static Domain CreateDomain(string name, params int[] pageNumbers) => CreateDomain(name, name, pageNumbers);
    public static Domain CreateDomain(string name, string search, params int[] pageNumbers)
    {
        var retval = new Domain();
        retval.Name = name;
        retval.Search = search;

        db.Add(new DomainAppearance()
        { 
            Source = Source,
            Entity = retval,
            PageNumbers = pageNumbers.Length == 0 ? "Throughout" : string.Join(',', pageNumbers)
        });
        return db.Add(retval).Entity;
    }

    public static Location CreateLocation(string name, params int[] pageNumbers) => CreateLocation(name, name, pageNumbers);
    public static Location CreateLocation(string name, string search, params int[] pageNumbers)
    {
        var retval = new Location();
        retval.Name = name;
        retval.Search = search;
        db.Add(new LocationAppearance()
        {
            Source = Source,
            Entity = retval,
            PageNumbers = pageNumbers.Length == 0 ? "Throughout" : string.Join(',', pageNumbers)
        });
        return db.Add(retval).Entity;
    }

    public static NPC CreateNPC(string name, params int[] pageNumbers) => CreateNPC(name, name, pageNumbers);
    public static NPC CreateNPC(string name, string search, params int[] pageNumbers)
    {
        var retval = new NPC();
        retval.Name = name;
        retval.Search = search;
        db.Add(new NPCAppearance()
        {
            Source = Source,
            Entity = retval,
            PageNumbers = pageNumbers.Length == 0 ? "Throughout" : string.Join(',', pageNumbers)
        });
        return db.Add(retval).Entity;
    }

    public static Item CreateItem(string name, params int[] pageNumbers) => CreateItem(name, name, pageNumbers);
    public static Item CreateItem(string name, string search , params int[] pageNumbers)
    {
        var retval = new Item();
        retval.Name = name;
        retval.Search = search;
        db.Add(new ItemAppearance()
        {
            Source = Source,
            Entity = retval,
            PageNumbers = pageNumbers.Length == 0 ? "Throughout" : string.Join(',', pageNumbers)
        });
        return db.Add(retval).Entity;
    }

    public static void CreateRelationship(NPC primary, RelationshipType type, NPC other)
    {
        var relationship = new Relationship()
        {
            Primary = primary,
            Type = type,
            Other = other
        };
        primary.Relationships.Add(relationship);
        other.Relationships.Add(relationship);
    }

    public static SourceTrait CreateSourceTrait(string name, string type) =>
        db.SourceTraits.Find(name) ?? db.SourceTraits.Add(new SourceTrait() { Name = name, Type = type }).Entity;

    public static Trait CreateTrait(string name, string type) =>
        db.Traits.Find(name) ?? db.Traits.Add(new Trait() { Name = name, Type = type }).Entity;
}

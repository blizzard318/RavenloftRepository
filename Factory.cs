//This script is for creating stuff to the database
//Adding stuff to the newly created stuff is handled in CrossAdd.cs
using NUglify.JavaScript.Syntax;
using Microsoft.EntityFrameworkCore;

internal class Factory : IDisposable
{
    #region PREGENERATED DATA
    public const string OutsideRavenloftOriginalName = "Outside Ravenloft", InsideRavenloftOriginalName = "Inside Ravenloft";

    private Domain _OutsideRavenloft, _InsideRavenloft;
    public Domain OutsideRavenloft
    {
        get
        {
            if (_OutsideRavenloft == null)
            {
                _OutsideRavenloft = CreateDomain(OutsideRavenloftOriginalName, string.Empty);
                _OutsideRavenloft.ExtraInfo = "Related to but outside Ravenloft.";
            }
            return _OutsideRavenloft;
        }
    }
    public Domain InsideRavenloft
    {
        get
        {
            if (_InsideRavenloft == null)
            {
                _InsideRavenloft = CreateDomain(InsideRavenloftOriginalName, string.Empty);
                _InsideRavenloft.ExtraInfo = "Within Ravenloft but unsure which domain.";
            }
            return _InsideRavenloft;
        }
    }

    public Group Darklords;
    public void CreateDarklordGroup(Domain domain, params NPC[] darklords)
    {
        var darklordgroup = CreateGroup("Darklord(s) of " + domain.OriginalName);
        domain.AddGroups(Darklords, darklordgroup);
        if (darklords.Length > 0)
        {
            domain.AddNPCs(darklords);
            Darklords.AddNPCs(darklords);
            darklordgroup.AddNPCs(darklords);
        }
    }
    #endregion

    public readonly static RavenloftContext db = new RavenloftContext();
    private readonly Source Source;
    private readonly List<Domain> domains = new(); //For trait distribution

    public void Dispose () //There is a chance I miss stuff out if its nested more than one layer.
    {
        foreach (var domain in domains)
        {
            foreach (var entity in domain.Locations) domain.Traits.UnionWith(entity.Traits);
            foreach (var entity in domain.NPCs) domain.Traits.UnionWith(entity.Traits);
            foreach (var entity in domain.Groups) domain.Traits.UnionWith(entity.Traits);
            foreach (var entity in domain.Items) domain.Traits.UnionWith(entity.Traits);
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
    private T Create<T,U>(string name, string originalName, string pageNumbers = "Throughout") where T : UseVariableName, new() where U : Appearance, IHasEntity<T>, new()
    {
        T retval = GetSet().Add(new()
        {
            Key = Source.Key + "/" + name,
            Name = name,
            OriginalName = originalName
        }).Entity;
        GetAppearanceSet().Add(new()
        {
            Source = Source,
            Entity = retval,
            PageNumbers = pageNumbers
        });

        return retval;

        static DbSet<T>? GetSet ()
        {
            var type = typeof(T);
            if (type == typeof(Domain  )) return db.Domains   as DbSet<T>;
            if (type == typeof(Location)) return db.Locations as DbSet<T>;
            if (type == typeof(Item    )) return db.Items     as DbSet<T>;
            if (type == typeof(NPC     )) return db.NPCs      as DbSet<T>;
            if (type == typeof(Group   )) return db.Groups    as DbSet<T>;
            throw new NotImplementedException();
        }
        static DbSet<U>? GetAppearanceSet()
        {
            var type = typeof(T);
            if (type == typeof(Domain  )) return db.domainAppearances   as DbSet<U>;
            if (type == typeof(Location)) return db.locationAppearances as DbSet<U>;
            if (type == typeof(Item    )) return db.itemAppearances     as DbSet<U>;
            if (type == typeof(NPC     )) return db.npcAppearances      as DbSet<U>;
            if (type == typeof(Group   )) return db.groupAppearances    as DbSet<U>;
            throw new NotImplementedException();
        }
    }

    public Domain CreateDomain(string name, string pageNumbers = "Throughout") => CreateDomain(name, name, pageNumbers);
    public Domain CreateDomain(string name, string originalName, string pageNumbers)
    {
        var retval = Create<Domain, DomainAppearance>(name, originalName, pageNumbers);
        domains.Add(retval); //Important for trait distribution
        return retval;
    }

    public Location CreateLocation(string name, string pageNumbers = "Throughout") => CreateLocation(name, name, pageNumbers);
    public Location CreateLocation(string name, string originalName, string pageNumbers) => Create<Location, LocationAppearance>(name, originalName, pageNumbers);

    public NPC CreateNPC(string name, string pageNumbers = "Throughout") => CreateNPC(name, name, pageNumbers);
    public NPC CreateNPC(string name, string originalName, string pageNumbers) => Create<NPC, NPCAppearance>(name, originalName, pageNumbers);

    public Item CreateItem(string name, string pageNumbers = "Throughout") => CreateItem(name, name, pageNumbers);
    public Item CreateItem(string name, string originalName, string pageNumbers) => Create<Item, ItemAppearance>(name, originalName, pageNumbers);

    public Group CreateGroup(string name, string pageNumbers = "Throughout") => CreateGroup(name, name, pageNumbers);
    public Group CreateGroup(string name, string originalName, string pageNumbers) => Create<Group, GroupAppearance>(name, originalName, pageNumbers);

    public void CreateRelationship(NPC primary, string RelationshipType, NPC other)
    {
        var relationship = new Relationship()
        {
            Primary = primary,
            RelationshipType = RelationshipType,
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

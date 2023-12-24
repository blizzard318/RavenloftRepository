//This script is for creating stuff to the database
//Adding stuff to the newly created stuff is handled in CrossAdd.cs
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
    public static string DarklordGroupName(string domain) => $"Darklord(s) of {domain}";
    public void CreateDarklordGroup(Domain domain, params NPC[] darklords)
    {
        var darklordgroup = CreateGroup(DarklordGroupName(domain.OriginalName));
        domain.AddGroups(Darklords, darklordgroup);
        domain.AddNPCs(darklords);
        Darklords.AddNPCs(darklords);
        darklordgroup.AddNPCs(darklords);
    }
    #endregion

    public readonly static RavenloftContext db = new RavenloftContext();
    private readonly Source Source;
    private readonly List<Domain> domains = new(); //For trait distribution

    public void Dispose () //There is a chance I miss stuff out if its nested more than one layer.
    {
        foreach (var domain in domains)
        {
            domain.Appearances[Source].Traits.UnionWith(domain.Locations[Source].SelectMany(e => e.Appearances[Source].Traits));
            domain.Appearances[Source].Traits.UnionWith(domain.NPCs     [Source].SelectMany(e => e.Appearances[Source].Traits));
            domain.Appearances[Source].Traits.UnionWith(domain.Groups   [Source].SelectMany(e => e.Appearances[Source].Traits));
            domain.Appearances[Source].Traits.UnionWith(domain.Items    [Source].SelectMany(e => e.Appearances[Source].Traits));
        }
    }
    public static Factory? CreateSource(string name, string releaseDate, string extraInfo, Source.Trait Edition, Source.Trait Media, Source.Trait? Canon = null)
        => new Factory(name, releaseDate, extraInfo, Edition, Media, Canon);
    private Factory(string name, string releaseDate, string extraInfo, Source.Trait Edition, Source.Trait Media, Source.Trait? Canon)
    {
        Console.WriteLine($"Adding: {name}");
        Source = new Source(name, releaseDate, Edition, Media, Canon) { ExtraInfo = extraInfo };

        db.Sources.Add(Source);
        Edition.Sources.Add(Source);
        Media.Sources.Add(Source);
        Canon?.Sources.Add(Source);
    }
    private T Create<T>(string type, string originalName, string pageNumbers = "Throughout") where T : UseVariableName, IHasAppearances<T>, new()
    {
        var set = GetSet();
        set.TryGetValue(originalName, out var retval);
        if (retval == null) set.Add(originalName, retval = (T)new UseVariableName(originalName));
        retval.Appearances.Add(Source, new InSource<T>(retval, Source, pageNumbers));
        return retval;

        SortedDictionary<string, T>? GetSet ()
        {
            switch (type)
            {
                case "Domain"  : return db.Domains   as SortedDictionary<string, T>;
                case "Location": return db.Locations as SortedDictionary<string, T>;
                case "Item"    : return db.Items     as SortedDictionary<string, T>;
                case "NPC"     : return db.NPCs      as SortedDictionary<string, T>;
                case "Group"   : return db.Groups    as SortedDictionary<string, T>;
            }
            throw new NotImplementedException();
        }
    }

    public Domain CreateDomain(string originalName, string pageNumbers = "Throughout")
    {
        var retval = Create<Domain>("Domain", originalName, pageNumbers);
        domains.Add(retval); //Important for trait distribution
        return retval;
    }

    public UseVariableName CreateLocation(string originalName, string pageNumbers = "Throughout")
    {
        db.Locations.TryGetValue(originalName, out var retval);
        if (retval == null) db.Locations.Add(originalName, retval = new UseVariableName(originalName));
        retval.Appearances.Add(Source, new InSource<UseVariableName>(retval, Source, pageNumbers));
        return retval;
    }

    public NPC CreateNPC(string originalName, string pageNumbers = "Throughout") => CreateNPC(name, name, pageNumbers);

    public UseVariableName CreateItem(string originalName, string pageNumbers = "Throughout") => CreateItem(name, name, pageNumbers);

    public UseVariableName CreateGroup(string originalName, string pageNumbers = "Throughout") => CreateGroup(name, name, pageNumbers);

    public void CreateRelationship(NPC primary, string RelationshipType, NPC other)
    {
        var relationship = new NPC.Relationship()
        {
            Primary = primary,
            RelationshipType = RelationshipType,
            Other = other,
        };
        primary.Relationships.Add(relationship);
        other.IgnoreThis.Add(relationship);
    }

    public static Source.Trait CreateSourceTrait(string name, string type)
    {
        //db.SourceTraits.Find(name) ?? db.SourceTraits.Add(new Source.Trait() { Key = name, Type = type }).Entity;
        var retval = db.SourceTraits.SingleOrDefault(s => s.Key == name);
        if (retval == null) db.SourceTraits.Add(retval = new Source.Trait() { Key = name, Type = type });
        return retval;
    }

    public static Trait CreateTrait(string name, params string[] types)
    {
        //db.Traits.Find(name) ?? db.Traits.Add(new Trait() { Key = name, Type = string.Join(',', types) }).Entity;
        var retval = db.Traits.SingleOrDefault(s => s.Key == name);
        if (retval == null) db.Traits.Add(retval = new Trait() { Key = name, Type = string.Join(',', types) });
        return retval;
    }
}

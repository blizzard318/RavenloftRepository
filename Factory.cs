﻿//This script is for creating stuff to the database
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
    private Enum EntityType { Domain, Location, Item, NPC, Group };

    private T Create<T>(EntityType type, string originalName, string pageNumbers = "Throughout") where T : UseVariableName, IHasAppearances<T>, new()
    {
        var set = GetSet(type);
        set.TryGetValue(originalName, out var retval);
        if (retval == null) set.Add(originalName, retval = (T)new UseVariableName(originalName));
        retval.Appearances.Add(Source, new InSource<T>(retval, Source, pageNumbers));
        return retval;

        static SortedDictionary<string, T>? GetSet (EntityType type)
        {
            switch (type)
            {
                case EntityType.Domain  : return db.Domains   as SortedDictionary<string, T>;
                case "Location": return db.Locations as SortedDictionary<string, T>;
                case EntityType.Item    : return db.Items     as SortedDictionary<string, T>;
                case EntityType.NPC     : return db.NPCs      as SortedDictionary<string, T>;
                case EntityType.Group   : return db.Groups    as SortedDictionary<string, T>;
            }
            throw new NotImplementedException();
        }
    }

    public Domain CreateDomain(string originalName, string pageNumbers = "Throughout")
    {
        var retval = Create<Domain>(EntityType.Domain, originalName, pageNumbers);
        domains.Add(retval); //Important for trait distribution
        return retval;
    }

    public UseVariableName CreateLocation(string originalName, string pageNumbers = "Throughout") => Create<UseVariableName>(EntityType.Location, originalName, pageNumbers);

    public NPC CreateNPC(string originalName, string pageNumbers = "Throughout") => Create<NPC>(EntityType.NPC, originalName, pageNumbers);

    public UseVariableName CreateItem(string originalName, string pageNumbers = "Throughout") => Create<UseVariableName>(EntityType.Item, originalName, pageNumbers);

    public UseVariableName CreateGroup(string originalName, string pageNumbers = "Throughout") => Create<UseVariableName>(EntityType.Group, originalName, pageNumbers);

    public void CreateRelationship(NPC primary, string RelationshipType, NPC other)
    {
        var relationship = new NPC.Relationship()
        {
            Primary = primary,
            RelationshipType = RelationshipType,
            Other = other,
        };
        primary.Relationships.Add(relationship);
other.Relationshops.Add(relationship);
    }

private enum SourceTraitType { Media, Edition, Canon };
private static Source.Trait CreateSourceTrait(SourceTraitType type, string name)
    {
        var retval = new Source.Trait(name);
GetList(type).Add(retval);
        return retval;

List<Source.Trait> GetList (SourceTraitType type)
{
   switch (type)
{
   case SourceTraitType.Media: return db. Medias;
   case SourceTraitType.Edition : return db.Editions;
    case SourceTraitType.Canon : return db.Canons;
}
throw new NotImplementedException();
}
    }
    public static Source.Trait CreateMediaTrait(string name) => 
public static Source.Trait CreateMediaTrait(string name)
    {
        var retval = new Source.Trait(name);
db.Medias.Add(retval);
        return retval;
    }
public static Source.Trait CreateMediaTrait(string name)
    {
        var retval = new Source.Trait(name);
db.Medias.Add(retval);
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

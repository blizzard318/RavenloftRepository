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

    public enum Edition { e1, e2, e3, e35, e4, e5, e0 };
    private static readonly Dictionary<Edition, string> EditionToString = new Dictionary<Edition, string>()
        {
            { Edition.e1 , "1st Ed"},
            { Edition.e2 , "2nd Ed"},
            { Edition.e3 , "3rd Ed"},
            { Edition.e35, "3.5th Ed"},
            { Edition.e4 , "4th Ed"},
            { Edition.e5 , "5th Ed"},
            { Edition.e0 , "Editionless"}
        };
    public enum Media { sourcebook, module, magazine, novel, gamebook, videogame, comic, boardgame, miniature };
    private static readonly Dictionary<Media, string> MediaToString = new Dictionary<Media, string>()
        {
            { Media.sourcebook , "Sourcebook"},
            { Media.module     , "Module"    },
            { Media.magazine   , "Magazine"  },
            { Media.novel      , "Novel"     },
            { Media.gamebook   , "Gamebook"  },
            { Media.videogame  , "Video Game"},
            { Media.comic      , "Comic"     },
            { Media.boardgame  , "Board Game"},
            { Media.miniature  , "Miniature" }
        };
    public enum Canon { pc, nc };
    private static readonly Dictionary<Canon, string> CanonToString = new Dictionary<Canon, string>()
        {
            { Canon.pc , "Potentially Canon"},
            { Canon.nc , "Not Canon"}
        };
    static Factory()
    {
        foreach (var kv in EditionToString) Ravenloftdb.Editions.Add(kv.Value, new());
        foreach (var kv in CanonToString) Ravenloftdb.Canons.Add(kv.Value, new());
        foreach (var kv in MediaToString) Ravenloftdb.Medias.Add(kv.Value, new());
    }
    #endregion

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

    public static Factory? CreateSource(string name, string releaseDate, string extraInfo, Edition Edition, Media Media, Canon? Canon = null)
        => new Factory(name, releaseDate, extraInfo, Edition, Media, Canon);
    private Factory(string name, string releaseDate, string extraInfo, Edition Edition, Media Media, Canon? Canon)
    {
        Console.WriteLine($"Adding: {name}");
        var edition = EditionToString[Edition];
        var media = MediaToString[Media];
        var canon = Canon != null ? CanonToString[Canon.Value] : null;
        Source = new Source(name, releaseDate, edition, media, canon) { ExtraInfo = extraInfo };

        Ravenloftdb.Sources.Add(Source);
        Ravenloftdb.Editions[edition].Add(Source);
        Ravenloftdb.Medias[media].Add(Source);
        if (Canon != null) Ravenloftdb.Canons[canon].Add(Source);
    }

    private enum EntityType { Domain, Location, Item, NPC, Group };
    private T Create<T>(EntityType type, string originalName, string pageNumbers = "Throughout") where T : UseVariableName, IHasAppearances<T>, new()
    {
        var set = GetSet(type);
        set.TryGetValue(originalName, out var retval);
        if (retval == null) set.Add(originalName, retval = new T() { OriginalName = originalName });
        retval.Appearances.Add(Source, new InSource<T>(retval, Source, pageNumbers));
        return retval;

        static SortedDictionary<string, T>? GetSet (EntityType type)
        {
            switch (type)
            {
                case EntityType.Domain  : return Ravenloftdb.Domains   as SortedDictionary<string, T>;
                case EntityType.Location: return Ravenloftdb.Locations as SortedDictionary<string, T>;
                case EntityType.Item    : return Ravenloftdb.Items     as SortedDictionary<string, T>;
                case EntityType.NPC     : return Ravenloftdb.NPCs      as SortedDictionary<string, T>;
                case EntityType.Group   : return Ravenloftdb.Groups    as SortedDictionary<string, T>;
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
        var relationship = new NPC.Relationship(primary, RelationshipType, other);
        primary.Relationships[Source].Add(relationship);
        other.Relationships[Source].Add(relationship);
    }
}

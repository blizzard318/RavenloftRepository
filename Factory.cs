//This script is for creating stuff to the database
//Adding stuff to the newly created stuff is handled in CrossAdd.cs

public partial class Factory : IDisposable
{
    #region PREGENERATED DATA
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
    static Factory()
    {
        SetUpSourceTraits();
        SetUpDomains();
        SetUpClusters();
    }
    #endregion

    #region SOURCE
    [Flags] public enum Edition { e0 = 1, e1 = 2, e2 = 4, e3 = 8, e35 = 16, e4 = 32, e5 = 64 };
    public static readonly Dictionary<Edition, string> EditionToString = new Dictionary<Edition, string>()
        {
            { Edition.e0 , "Editionless"},
            { Edition.e1 , "1st Ed"     },
            { Edition.e2 , "2nd Ed"     },
            { Edition.e3 , "3rd Ed"     },
            { Edition.e35, "3.5th Ed"   },
            { Edition.e4 , "4th Ed"     },
            { Edition.e5 , "5th Ed"     }
        };
    public enum Media { sourcebook, module, magazine, novel, gamebook, videogame, comic, boardgame, miniature };
    public static readonly Dictionary<Media, string> MediaToString = new Dictionary<Media, string>()
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
    public static readonly Dictionary<Canon, string> CanonToString = new Dictionary<Canon, string>()
        {
            { Canon.pc , "Potentially Canon"},
            { Canon.nc , "Not Canon"        }
        };
    private static void SetUpSourceTraits()
    {
        foreach (var edition in Enum.GetValues<Edition>()) Ravenloftdb.Editions.Add(edition, new());
        foreach (var canon   in Enum.GetValues<Canon  >()) Ravenloftdb.Canons  .Add(canon  , new());
        foreach (var media   in Enum.GetValues<Media  >()) Ravenloftdb.Medias  .Add(media  , new());
    }
    private readonly Source Source;

    public static Factory? CreateSource(string name, string releaseDate, string extraInfo, Edition Edition, Media Media, Canon? Canon = null)
        => new Factory(name, releaseDate, extraInfo, Edition, Media, Canon);
    private Factory(string name, string releaseDate, string extraInfo, Edition Edition, Media Media, Canon? Canon)
    {
        Console.WriteLine($"Adding: {name}");
        Source = new Source(name, releaseDate, Edition, Media, Canon) { ExtraInfo = extraInfo };

        Ravenloftdb.Sources.Add(Source);
        Ravenloftdb.Editions[Edition].Add(Source);
        Ravenloftdb.Medias[Media].Add(Source);
        if (Canon != null) Ravenloftdb.Canons[Canon.Value].Add(Source);
    }
    #endregion

    private enum EntityType { Domain, Location, Item, NPC, Group };
    private T Create<T>(EntityType type, string Name, string pageNumbers = "Throughout") where T : UseVariableName, IHasAppearances<T>, new()
    {
        var set = GetSet(type);
        set.TryGetValue(Name, out var retval);
        if (retval == null)
        {
            set.Add(Name, retval = new T());
            retval.Names.Add(Name);
        }
        retval.Appearances.Add(Source, new InSource<T>(retval, Source, pageNumbers));
        return retval;

        static SortedDictionary<string, T>? GetSet (EntityType type)
        {
            switch (type)
            {
                case EntityType.Domain  : return Ravenloftdb.Domains    as SortedDictionary<string, T>;
                case EntityType.Location: return Ravenloftdb.Locations  as SortedDictionary<string, T>;
                case EntityType.Item    : return Ravenloftdb.Items      as SortedDictionary<string, T>;
                case EntityType.NPC     : return Ravenloftdb.Characters as SortedDictionary<string, T>;
                case EntityType.Group   : return Ravenloftdb.Groups     as SortedDictionary<string, T>;
            }
            throw new NotImplementedException();
        }
    }

    public UseVariableName CreateLocation(string originalName, string pageNumbers = "Throughout") => Create<Location>(EntityType.Location, originalName, pageNumbers);

    public NPC CreateNPC(string originalName, string pageNumbers = "Throughout") => Create<NPC>(EntityType.NPC, originalName, pageNumbers);

    public UseVariableName CreateItem(string originalName, string pageNumbers = "Throughout") => Create<Item>(EntityType.Item, originalName, pageNumbers);

    public UseVariableName CreateGroup(string originalName, string pageNumbers = "Throughout") => Create<Group>(EntityType.Group, originalName, pageNumbers);

    public void CreateRelationship(NPC primary, string RelationshipType, NPC other)
    {
        var relationship = new NPC.Relationship(primary, RelationshipType, other);
        primary.Relationships[Source].Add(relationship);
        other.Relationships[Source].Add(relationship);
    }
}

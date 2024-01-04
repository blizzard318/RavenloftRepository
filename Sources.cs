public partial class Factory : IDisposable
{
    [Flags] public enum Edition { e0 = 1, e1 = 1 << 1, e2 = 1 << 2, e3 = 1 << 3, e35 = 1 << 4, e4 = 1 << 5, e5 = 1 << 6 };
    public static string EditionToString (Edition e)
    {
        var retval = new List<string>();
        if (e.HasFlag(Edition.e0 )) retval.Add("Editionless");
        if (e.HasFlag(Edition.e1 )) retval.Add("1st Ed"     );
        if (e.HasFlag(Edition.e2 )) retval.Add("2nd Ed"     );
        if (e.HasFlag(Edition.e3 )) retval.Add("3rd Ed"     );
        if (e.HasFlag(Edition.e35)) retval.Add("3.5th Ed"   );
        if (e.HasFlag(Edition.e4 )) retval.Add("4th Ed"     );
        if (e.HasFlag(Edition.e5 )) retval.Add("5th Ed"     );
        return string.Join(", ", retval);
    }
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
    public enum Canon { c, pc, nc };
    public static readonly Dictionary<Canon, string> CanonToString = new Dictionary<Canon, string>()
        {
            { Canon.pc , "Potentially Canon"},
            { Canon.nc , "Not Canon"        }
        };
    private static void SetUpSourceTraits()
    {
        foreach (var edition in Enum.GetValues<Edition>()) Ravenloftdb.Editions.Add(edition, new());
        foreach (var canon in Enum.GetValues<Canon>()) Ravenloftdb.Canons.Add(canon, new());
        foreach (var media in Enum.GetValues<Media>()) Ravenloftdb.Medias.Add(media, new());
    }
    private readonly Source Source;

    public static Factory CreateSource(string name, string releaseDate, string extraInfo, Edition Edition, Media Media, Canon Canon = Canon.c)
        => new Factory(name, releaseDate, extraInfo, Edition, Media, Canon);
    private Factory(string name, string releaseDate, string extraInfo, Edition Edition, Media Media, Canon Canon)
    {
        Console.WriteLine($"Adding: {name}");
        Source = new Source(name, releaseDate, Edition, Media, Canon) { ExtraInfo = extraInfo };

        Ravenloftdb.Sources.Add(Source);
        Ravenloftdb.Editions[Edition].Add(Source);
        Ravenloftdb.Medias[Media].Add(Source);
        if (Canon != Canon.c) Ravenloftdb.Canons[Canon].Add(Source);
    }
}

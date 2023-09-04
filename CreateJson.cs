using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

internal static class CreateJson
{
    private static JsonSerializerOptions opt = new JsonSerializerOptions
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin),
        WriteIndented = true
    };
    public static void CreateSourcess()
    {
        var Sources = Factory.db.Sources.Include(s => s.Traits).ToArray();
        var sources = new List<JsonSource>();
        foreach (var source in Sources)
        {
            sources.Add(new JsonSource()
            {
                Name = source.Key,
                Edition = source.Traits.Single(s => s.Type == nameof(Traits.Edition)).Key,
                ReleaseDate = source.ReleaseDate,
                MediaType = source.Traits.Single(s => s.Type == nameof(Traits.Media)).Key
            });
        }

        var dir = Directory.CreateDirectory(nameof(Source)).ToString();
        string filepath = Path.Join(dir, "data.json");
        File.WriteAllText(filepath, JsonSerializer.Serialize(sources, opt));
    }
    public static void CreateDomains()
    {
        var Sources = Factory.db.Sources.Include(s => s.Traits).ToHashSet();
        var mediatypes = new List<JsonDomain>();
        foreach (var mediaType in Traits.Media.Medias)
        {
            var SourcesByEdition = Sources.Where(s => s.Traits.Contains(mediaType)).ToArray();
            var sources = new List<JsonMedia.Source>();
            foreach (var source in SourcesByEdition)
            {
                Sources.Remove(source);
                sources.Add(new JsonMedia.Source()
                {
                    Name = source.Key,
                    Edition = source.Traits.Single(s => s.Type == nameof(Traits.Edition)).Key,
                    ReleaseDate = source.ReleaseDate,
                });
            }

            mediatypes.Add(new JsonDomain()
            {
                Name = mediaType.Key,
                Sources = sources
            });
            Console.WriteLine(JsonSerializer.Serialize(mediatypes[mediatypes.Count() - 1]));
        }

        var dir = Directory.CreateDirectory(nameof(Traits.Media)).ToString();
        string filepath = Path.Join(dir, "data.json");
        File.WriteAllText(filepath, JsonSerializer.Serialize(mediatypes, opt));
    }
}
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
        var Domains = Factory.db.Domains.Include(s => s.Traits).Include(s => s.NPCs).ThenInclude(n => n.Traits).ToHashSet();
        var domains = new List<JsonDomain>();
        foreach (var domain in Domains)
        {
            var SameDomainButDifferentNames = Domains.Where(d => d.OriginalName == domain.Name).ToArray();

            var DifferentNamesOfSameDomain = new HashSet<string>();
            var Darklords = new HashSet<string>();
            foreach (var SameDomain in SameDomainButDifferentNames) //Get all domains
            {
                Domains.Remove(SameDomain);
                DifferentNamesOfSameDomain.Add(SameDomain.Name);

                var DomainDarklords = SameDomain.NPCs.Where(n => n.Traits.Contains(Traits.Status.Darklord)).ToHashSet();
                foreach (var DomainDarklord in DomainDarklords)
                {
                    var DarklordAlternateNames = DomainDarklords.Where(d => d.Key == DomainDarklord.Key);
                    foreach (var ToRemove in DarklordAlternateNames) DomainDarklords.Remove(ToRemove);
                    Darklords.Add(string.Join('/', DarklordAlternateNames));
                }
            }

            var sources = Factory.db.domainAppearances.Include(a => a.Source.Traits).Where(a => a.EntityId == domain.Key);
            var editions = sources.Select(a => a.Source.Traits).Distinct().ToList();

            domains.Add(new JsonDomain()
            {
                Name = string.Join('/', DifferentNamesOfSameDomain),
                Darklords = string.Join(',', Darklords),
                //Clusters = default,
                Editions = string.Join(',', editions),
                Sources = sources.Count()
            });
        }

        var dir = Directory.CreateDirectory(nameof(Domain)).ToString();
        string filepath = Path.Join(dir, "data.json");
        File.WriteAllText(filepath, JsonSerializer.Serialize(mediatypes, opt));
    }
}
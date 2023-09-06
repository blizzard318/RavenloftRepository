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
    public static void CreateSources()
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
            var Clusters = new HashSet<string>();
            var Darklords = new HashSet<string>();
            var DifferentNamesOfSameDomain = new HashSet<string>();
            var SameDomainButDifferentNames = Domains.Where(d => d.OriginalName == domain.OriginalName).ToArray();
            foreach (var SameDomain in SameDomainButDifferentNames) //Get all variant domains of the original domain
            {
                Domains.Remove(SameDomain);
                DifferentNamesOfSameDomain.Add(SameDomain.Name);

                var DomainDarklords = SameDomain.NPCs.Where(n => n.Traits.Contains(Traits.Status.Darklord)).ToHashSet();
                foreach (var DomainDarklord in DomainDarklords) //Go through all darklords
                {
                    var AlternateNames = new List<string>();
                    var DarklordAlternateNames = DomainDarklords.Where(d => d.OriginalName == DomainDarklord.OriginalName);
                    foreach (var ToAdd in DarklordAlternateNames) //So far there actually are no Darklords with different names.
                    {
                        DomainDarklords.Remove(ToAdd);
                        AlternateNames.Add(ToAdd.Name);
                    }
                    Darklords.Add(string.Join('/', AlternateNames));
                }

                var DomainClusters = SameDomain.Traits.Where(t => t.Type == nameof(Traits.Cluster)).ToArray();
                foreach (var Cluster in DomainClusters) Clusters.Add(Cluster.Key);
            }

            var Editions = new int[Traits.Edition.Editions.Count];
            var Sources = Factory.db.domainAppearances.Include(a => a.Source.Traits).Where(a => a.Entity.OriginalName == domain.OriginalName);
            foreach (var Source in Sources)
            {
                var Edition = Source.Source.Traits.Single(t => t.Type == nameof(Traits.Edition));
                Editions[Traits.Edition.Editions.IndexOf(Edition)]++;
            }

            domains.Add(new JsonDomain()
            {
                Name = string.Join('/', DifferentNamesOfSameDomain),
                Darklords = string.Join(',', Darklords),
                Clusters = string.Join(',', Clusters),
                Editions = Editions
            });
        }

        var dir = Directory.CreateDirectory(nameof(Domain)).ToString();
        string filepath = Path.Join(dir, "data.json");
        File.WriteAllText(filepath, JsonSerializer.Serialize(domains, opt));
    }
    public static void CreateItems()
    {
        var Items = Factory.db.Items.Include(s => s.Traits).Include(s => s.Domains).ToHashSet();
        var items = new List<JsonItem>();
        foreach (var item in Items)
        {
            var DifferentNamesOfSameDomain = new HashSet<string>();
            var DifferentNamesOfSameItem = new HashSet<string>();
            var SameItemButDifferentNames = Items.Where(d => d.OriginalName == item.Name).ToArray();
            foreach (var SameItem in SameItemButDifferentNames) //Get all domains
            {
                Items.Remove(SameItem);
                DifferentNamesOfSameItem.Add(SameItem.Name);
                foreach (var domain in SameItem.Domains)
                {
                    var SameDomainButDifferentNames = Factory.db.Domains.Where(d => d.OriginalName == domain.OriginalName);
                    foreach (var SameDomain in SameDomainButDifferentNames) DifferentNamesOfSameDomain.Add(SameDomain.Name);
                }
            }

            var Editions = new int[Traits.Edition.Editions.Count];
            var Sources = Factory.db.itemAppearances.Include(a => a.Source.Traits).Where(a => a.Entity.OriginalName == item.OriginalName);
            foreach (var Source in Sources)
            {
                var Edition = Source.Source.Traits.Single(t => t.Type == nameof(Traits.Edition));
                Editions[Traits.Edition.Editions.IndexOf(Edition)]++;
            }

            items.Add(new JsonItem()
            {
                Name = string.Join('/', DifferentNamesOfSameItem),
                Domains = string.Join(',', DifferentNamesOfSameDomain),
                Editions = Editions
            });
        }

        var dir = Directory.CreateDirectory(nameof(Item)).ToString();
        string filepath = Path.Join(dir, "data.json");
        File.WriteAllText(filepath, JsonSerializer.Serialize(items, opt));
    }
}
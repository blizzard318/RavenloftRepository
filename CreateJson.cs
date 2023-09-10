using Humanizer.Localisation;
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

    private static void SaveDataJson<T> (string DirectoryName, T ToSaveInside)
    {
        var dir = Directory.CreateDirectory(DirectoryName).ToString();
        string filepath = Path.Join(dir, "data.json");
        string contents = JsonSerializer.Serialize(ToSaveInside, opt).Replace("\\u0027", "'");
        File.WriteAllText(filepath, contents);
    }
    public static void CreateEditions() => File.WriteAllText("Edition.csv", string.Join(",", Traits.Edition.Editions));
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
        SaveDataJson(nameof(Source), sources);
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

            var Editions = new bool[Traits.Edition.Editions.Count];
            var Sources = Factory.db.domainAppearances.Include(a => a.Source.Traits).Where(a => a.Entity.OriginalName == domain.OriginalName);
            foreach (var Source in Sources)
            {
                var Edition = Source.Source.Traits.Single(t => t.Type == nameof(Traits.Edition));
                Editions[Traits.Edition.Editions.IndexOf(Edition)] = true;
            }

            domains.Add(new JsonDomain()
            {
                Name = string.Join('/', DifferentNamesOfSameDomain),
                Darklords = string.Join(',', Darklords),
                Clusters = string.Join(',', Clusters),
                Editions = Editions
            });
        }
        SaveDataJson(nameof(Domain), domains);
    }    
    public static void CreateLocations()
    {
        var Locations = Factory.db.Locations.Include(s => s.Traits).Include(s => s.Domains).Include(s => s.NPCs).ThenInclude(n => n.Traits).ToHashSet();
        var locations = new List<JsonLocation>();

        foreach (var location in Locations)
        {
            var Types = new HashSet<string>();
            var DifferentNamesOfSameDomain = new HashSet<string>();
            var DifferentNamesOfSameLocation = new HashSet<string>();
            var SameLocationButDifferentNames = Locations.Where(d => d.OriginalName == location.OriginalName).ToArray();
            foreach (var SameLocation in SameLocationButDifferentNames) //Get all variant domains of the original domain
            {
                Locations.Remove(SameLocation);
                DifferentNamesOfSameLocation.Add(SameLocation.Name);
                foreach (var domain in SameLocation.Domains)
                {
                    var SameDomainButDifferentNames = Factory.db.Domains.Where(d => d.OriginalName == domain.OriginalName);
                    foreach (var SameDomain in SameDomainButDifferentNames) DifferentNamesOfSameDomain.Add(SameDomain.Name);
                }

                if (SameLocation.Traits.Any(l => l == Traits.Location.Mistway)) Types.Add(nameof(Traits.Mistway));
                if (SameLocation.Traits.Any(l => l == Traits.Location.Settlement)) Types.Add(nameof(Traits.Settlement));
                if (SameLocation.Traits.Any(l => l == Traits.Location.Darklord))
                {
                    var Darklords = new List<string>();
                    var DomainDarklords = SameLocation.NPCs.Where(n => n.Traits.Contains(Traits.Status.Darklord)).ToHashSet();
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
                    Types.Add(nameof(Traits.Location.Darklord) + string.Join(',', Darklords));
                }
            }

            var Editions = new bool[Traits.Edition.Editions.Count];
            var Sources = Factory.db.locationAppearances.Include(a => a.Source.Traits).Where(a => a.Entity.OriginalName == location.OriginalName);
            foreach (var Source in Sources)
            {
                var Edition = Source.Source.Traits.Single(t => t.Type == nameof(Traits.Edition));
                Editions[Traits.Edition.Editions.IndexOf(Edition)] = true;
            }

            locations.Add(new JsonLocation()
            {
                Name = string.Join('/', DifferentNamesOfSameLocation),
                Domains = string.Join(',', DifferentNamesOfSameDomain),
                Types = string.Join(',', Types),
                Editions = Editions
            });
        }
        SaveDataJson(nameof(Location), locations);
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

            var Editions = new bool[Traits.Edition.Editions.Count];
            var Sources = Factory.db.itemAppearances.Include(a => a.Source.Traits).Where(a => a.Entity.OriginalName == item.OriginalName);
            foreach (var Source in Sources)
            {
                var Edition = Source.Source.Traits.Single(t => t.Type == nameof(Traits.Edition));
                Editions[Traits.Edition.Editions.IndexOf(Edition)] = true;
            }

            items.Add(new JsonItem()
            {
                Name = string.Join('/', DifferentNamesOfSameItem),
                Domains = string.Join(',', DifferentNamesOfSameDomain),
                Editions = Editions
            });
        }
        SaveDataJson(nameof(Item), items);
    }
}
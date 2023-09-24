using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
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
        string filepath = Path.Join(dir, $"{DirectoryName}.json");
        string contents = JsonSerializer.Serialize(ToSaveInside, opt);
        contents = contents.Replace("\\u0027", "'");
        contents = contents.Replace("\\u003C", "<");
        contents = contents.Replace("\\u003E", ">");
        File.WriteAllText(filepath, contents);
    }
    private static void AddLink (this ICollection<string> list, string subdomain, string name) => list.Add(AddLink(subdomain, name));
    private static string AddLink(string subdomain, string name) => $"<a href='/{subdomain}/{name}'>{name}</a>";
    public static void CreateEditions() => File.WriteAllText("Edition.csv", string.Join(",", Traits.Edition.Editions));
    public static void CreateSources()
    {
        var Sources = Factory.db.Sources.Include(s => s.Traits).ToArray();
        var sources = new List<JsonSource>();
        foreach (var source in Sources)
        {
            sources.Add(new JsonSource()
            {
                Name = AddLink(nameof(Source), source.Key),
                Edition = source.Traits.Single(s => s.Type == nameof(Traits.Edition)).Key,
                ReleaseDate = source.ReleaseDate,
                MediaType = source.Traits.Single(s => s.Type == nameof(Traits.Media)).Key
            });
        }
        SaveDataJson(nameof(Source), sources);
    }
    public static void CreateDomains()
    {
        var Domains = Factory.db.Domains
            .Include(s => s.Traits).Include(s => s.NPCs).ThenInclude(n => n.Traits)
            .GroupBy(s => s.Name).Select(g => g.First()).ToHashSet();
        var domains = new List<JsonDomain>();
        foreach (var domain in Domains)
        {
            var Clusters = new List<string>();
            var Darklords = new List<string>();
            var DifferentNamesOfSameDomain = new List<string>();
            var SameDomainButDifferentNames = Domains.Where(d => d.OriginalName == domain.OriginalName).ToArray();
            foreach (var SameDomain in SameDomainButDifferentNames) //Get all variant domains of the original domain
            {
                Domains.Remove(SameDomain);
                DifferentNamesOfSameDomain.AddLink(nameof(Domain),SameDomain.Name);

                var DomainDarklords = SameDomain.NPCs.Where(n => n.Traits.Contains(Traits.Status.Darklord)).ToHashSet();
                foreach (var DomainDarklord in DomainDarklords) //Go through all darklords
                {
                    var AlternateNames = new List<string>();
                    var DarklordAlternateNames = DomainDarklords.Where(d => d.OriginalName == DomainDarklord.OriginalName);
                    foreach (var ToAdd in DarklordAlternateNames) //So far there actually are no Darklords with different names.
                    {
                        DomainDarklords.Remove(ToAdd);
                        AlternateNames.AddLink("Character", ToAdd.Name);
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
        var Locations = Factory.db.Locations
            .Include(s => s.Traits).Include(s => s.Domains).Include(s => s.NPCs).ThenInclude(n => n.Traits)
            .GroupBy(s => s.Name).Select(g => g.First()).ToHashSet();
        var locations = new List<JsonLocation>();
        foreach (var location in Locations)
        {
            var Types = new HashSet<string>();
            var TotalDomains = new List<string>();
            var DifferentNamesOfSameLocation = new List<string>();
            var SameLocationButDifferentNames = Locations.Where(d => d.OriginalName == location.OriginalName).ToArray();
            foreach (var SameLocation in SameLocationButDifferentNames) //Get all variant domains of the original domain
            {
                Locations.Remove(SameLocation);
                DifferentNamesOfSameLocation.AddLink(nameof(Location), SameLocation.Name);

                var DifferentNamesOfSameDomain = new List<string>();
                foreach (var domain in SameLocation.Domains)
                {
                    var SameDomainButDifferentNames = Factory.db.Domains.Where(d => d.OriginalName == domain.OriginalName);
                    foreach (var SameDomain in SameDomainButDifferentNames) DifferentNamesOfSameDomain.AddLink(nameof(Domain), SameDomain.Name);
                }
                TotalDomains.Add(string.Join("/", DifferentNamesOfSameDomain));

                if (SameLocation.Traits.Any(l => l == Traits.Location.Mistway))    Types.Add(nameof(Traits.Mistway   ));
                if (SameLocation.Traits.Any(l => l == Traits.Location.Settlement)) Types.Add(nameof(Traits.Settlement));
                if (SameLocation.Traits.Any(l => l == Traits.Location.Darklord)) //Keep this last
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
                            AlternateNames.AddLink("Character", ToAdd.Name);
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
                Domains = string.Join(',', TotalDomains),
                Types = string.Join(',', Types),
                Editions = Editions
            });
        }
        SaveDataJson(nameof(Location), locations);
    }
    public static void CreateItems()
    {
        var Items = Factory.db.Items
            .Include(s => s.Traits).Include(s => s.Domains)
            .GroupBy(s => s.Name).Select(g => g.First()).ToHashSet(); 
        var items = new List<JsonItem>();
        foreach (var item in Items)
        {
            var Groups = new HashSet<string>();
            var TotalDomains = new List<string>();
            var DifferentNamesOfSameItem = new List<string>();
            var SameItemButDifferentNames = Items.Where(d => d.OriginalName == item.Name).ToArray();
            foreach (var SameItem in SameItemButDifferentNames) //Get all domains
            {
                Items.Remove(SameItem);
                DifferentNamesOfSameItem.AddLink(nameof(Item), SameItem.Name);

                var DifferentNamesOfSameDomain = new HashSet<string>();
                foreach (var domain in SameItem.Domains)
                {
                    var SameDomainButDifferentNames = Factory.db.Domains.Where(d => d.OriginalName == domain.OriginalName);
                    foreach (var SameDomain in SameDomainButDifferentNames) DifferentNamesOfSameDomain.AddLink(nameof(Domain), SameDomain.Name);
                }
                TotalDomains.Add(string.Join("/", DifferentNamesOfSameDomain));

                var StatusTraits = SameItem.Traits.Where(c => c.Type.Contains(nameof(Traits.Status)));
                foreach (var statusTrait in StatusTraits) Groups.AddLink("Group", statusTrait.Key);
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
                Domains = string.Join(',', TotalDomains),
                Groups = string.Join(',', Groups),
                Editions = Editions
            });
        }
        SaveDataJson(nameof(Item), items);
    }
    public static void CreateLanguages()
    {
        var Languages = Factory.db.Traits.Include(t => t.Domains).Where(t => t.Type == nameof(Traits.Language)).GroupBy(s => s.Key).Select(g => g.First()).ToHashSet();
        var languages = new List<JsonLanguage>();
        foreach (var language in Languages)
        {
            var TotalDomains = new List<string>();
            var DifferentNamesOfSameDomain = new HashSet<string>();
            foreach (var domain in language.Domains)
            {
                var SameDomainButDifferentNames = Factory.db.Domains.Where(d => d.OriginalName == domain.OriginalName);
                foreach (var SameDomain in SameDomainButDifferentNames) DifferentNamesOfSameDomain.AddLink(nameof(Domain), SameDomain.Name);
            }
            TotalDomains.Add(string.Join("/", DifferentNamesOfSameDomain));

            languages.Add(new JsonLanguage()
            {
                Name = AddLink("Language", language.Key),
                Domains = string.Join(',', TotalDomains)
            });
        }
        SaveDataJson("Language", languages);
    }
    public static void CreateGroups()
    {
        var Groups = Factory.db.Traits.Include(t => t.Domains).Where(t => t.Type.Contains(nameof(Traits.Status))).GroupBy(s => s.Key).Select(g => g.First()).ToHashSet();
        var groups = new List<JsonGroup>();

        foreach (var group in Groups)
        {
            if (group == Traits.Status.Deceased) continue;
            var TotalDomains = new List<string>();
            var DifferentNamesOfSameDomain = new HashSet<string>();
            foreach (var domain in group.Domains)
            {
                var SameDomainButDifferentNames = Factory.db.Domains.Where(d => d.OriginalName == domain.OriginalName);
                foreach (var SameDomain in SameDomainButDifferentNames) DifferentNamesOfSameDomain.AddLink(nameof(Domain), SameDomain.Name);
            }
            TotalDomains.Add(string.Join("/", DifferentNamesOfSameDomain));

            groups.Add(new JsonGroup()
            {
                Name = AddLink("Group", group.Key),
                Domains = string.Join(',', TotalDomains)
            });
        }
        SaveDataJson("Group", groups);
    }
    public static void CreateCharacters()
    {
        var Characters = Factory.db.NPCs
            .Include(s => s.Traits).Include(s => s.Domains)
            .GroupBy(s => s.Name).Select(g => g.First()).ToHashSet(); 
        var characters = new List<JsonCharacter>();
        foreach (var character in Characters)
        {
            if (character.Traits.Contains(Traits.NoLink)) continue;
            var Types = new HashSet<string>();
            var TotalDomains = new List<string>();
            var DifferentNamesOfSameCharacter = new List<string>();
            var SameCharacterButDifferentNames = Characters.Where(d => d.OriginalName == character.Name).ToArray();
            foreach (var SameCharacter in SameCharacterButDifferentNames) //Get all domains
            {
                Characters.Remove(SameCharacter);
                DifferentNamesOfSameCharacter.AddLink("Character", SameCharacter.Name);

                var DifferentNamesOfSameDomain = new HashSet<string>();
                foreach (var domain in SameCharacter.Domains)
                {
                    var SameDomainButDifferentNames = Factory.db.Domains.Where(d => d.OriginalName == domain.OriginalName);
                    foreach (var SameDomain in SameDomainButDifferentNames) DifferentNamesOfSameDomain.AddLink(nameof(Domain), SameDomain.Name);
                }
                TotalDomains.Add(string.Join("/", DifferentNamesOfSameDomain));

                var StatusTraits = SameCharacter.Traits.Where(c => c.Type.Contains(nameof(Traits.Status)));
                foreach (var statusTrait in StatusTraits)
                {
                    if (statusTrait == Traits.Status.Deceased) Types.Add(statusTrait.Key);
                    else Types.AddLink("Group", statusTrait.Key);
                }
            }

            var Editions = new bool[Traits.Edition.Editions.Count];
            var Sources = Factory.db.npcAppearances.Include(a => a.Source.Traits).Where(a => a.Entity.OriginalName == character.OriginalName);
            foreach (var Source in Sources)
            {
                var Edition = Source.Source.Traits.Single(t => t.Type == nameof(Traits.Edition));
                Editions[Traits.Edition.Editions.IndexOf(Edition)] = true;
            }

            characters.Add(new JsonCharacter()
            {
                Name = string.Join('/', DifferentNamesOfSameCharacter),
                Domains = string.Join(',', TotalDomains),
                Types = string.Join(',', Types),
                Editions = Editions
            });
        }
        SaveDataJson("Character", characters);
    }
}
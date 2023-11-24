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
        string filepath = Path.Join(dir, $"{DirectoryName}.json");
        string contents = JsonSerializer.Serialize(ToSaveInside, opt);
        contents = contents.Replace("\\u0027", "'");
        contents = contents.Replace("\\u003C", "<");
        contents = contents.Replace("\\u003E", ">");
        File.WriteAllText(filepath, contents);
    }
    private static void AddLink (this ICollection<string> list, string subdomain, string name) => list.Add(AddLink(subdomain, name));
    private static string AddLink(string subdomain, string name) => $"<a href='/{subdomain}/{name}'>{name}</a>";
    public static void CreateLanguages()
    {
        var Languages = Factory.db.Traits.Include(t => t.Domains).Where(t => t.Type == nameof(Traits.Language)).ToHashSet();
        var languages = new List<JsonLanguage>();
        foreach (var language in Languages)
        {
            var TotalDomains = new List<string>();
            var TotalNamesOfSameDomain = string.Empty;
            var DifferentNamesOfSameDomain = new HashSet<string>();
            foreach (var domain in language.Domains)
            {
                var SameDomainButDifferentNames = Factory.db.Domains
                    .Where(d => d.OriginalName == domain.OriginalName).Select(d => d.Name).ToHashSet();
                foreach (var SameDomainName in SameDomainButDifferentNames) DifferentNamesOfSameDomain.AddLink(nameof(Domain), SameDomainName);
                TotalNamesOfSameDomain = string.Join("/", DifferentNamesOfSameDomain);
            }
            TotalDomains.Add(string.Join(",", DifferentNamesOfSameDomain));

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
        var Groups = Factory.db.Traits.Include(t => t.Domains).Where(t => t.Type.Contains(nameof(Traits.Status))).ToHashSet();
        var groups = new List<JsonGroup>();

        foreach (var group in Groups)
        {
            if (group == Traits.Status.Deceased) continue;
            var TotalDomains = new List<string>();
            var TotalNamesOfSameDomain = string.Empty;
            var DifferentNamesOfSameDomain = new HashSet<string>();
            foreach (var domain in group.Domains)
            {
                var SameDomainButDifferentNames = Factory.db.Domains.Where(d => d.OriginalName == domain.OriginalName).Select(d => d.Name).ToHashSet();
                foreach (var SameDomainName in SameDomainButDifferentNames) DifferentNamesOfSameDomain.AddLink(nameof(Domain), SameDomainName);
                TotalNamesOfSameDomain = string.Join("/", DifferentNamesOfSameDomain);
            }
            TotalDomains.Add(string.Join(",", DifferentNamesOfSameDomain));

            groups.Add(new JsonGroup()
            {
                Name = AddLink("Group", group.Key),
                Domains = string.Join(',', TotalDomains)
            });
        }
        SaveDataJson("Group", groups);
    }
    public static void CreateCreatures()
    {
        var Creatures = Factory.db.Traits.Include(t => t.Domains).Where(t => t.Type.Contains(nameof(Traits.Creature))).ToHashSet();
        var creatures = new List<JsonCreature>();

        foreach (var creature in Creatures)
        {
            var TotalDomains = new List<string>();
            var TotalNamesOfSameDomain = string.Empty;
            var DifferentNamesOfSameDomain = new HashSet<string>();
            foreach (var domain in creature.Domains)
            {
                var SameDomainButDifferentNames = Factory.db.Domains
                    .Where(d => d.OriginalName == domain.OriginalName).Select(d => d.Name).ToHashSet();
                foreach (var SameDomainName in SameDomainButDifferentNames) DifferentNamesOfSameDomain.AddLink(nameof(Domain), SameDomainName);
                TotalNamesOfSameDomain = string.Join("/", DifferentNamesOfSameDomain);
            }
            TotalDomains.Add(string.Join(",", DifferentNamesOfSameDomain));

            creatures.Add(new JsonCreature()
            {
                Name = AddLink(nameof(Traits.Creature), creature.Key),
                Domains = string.Join(',', TotalDomains)
            });
        }
        SaveDataJson(nameof(Traits.Creature), creatures);
    }
}